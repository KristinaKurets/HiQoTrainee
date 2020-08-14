using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DB.Entity;
using DbScheduler.Job;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PortalApiCheck.Core;
using PortalApiCheck.Interfaces;
using Quartz;
using Quartz.Impl;
using Repository.Interface;
using Repository.Repositories;
using Repository.UnitOfWork;

namespace DbScheduler
{
    internal class Scheduler
    {
        private readonly IUserProvider userProvider;
        private readonly IRepository<User> usersRepository;
        private readonly IRepository<UserPosition> usersPositionsRepository;
        private readonly IUnitOfWork unitOfWork;
        private IScheduler scheduler;

        public Scheduler(IUserProvider userProvider, IUnitOfWork unitOfWork)
        {
            this.userProvider = userProvider;
            this.unitOfWork = unitOfWork;
            usersRepository = new UniqueUserRepository(unitOfWork.UserRepository);
            usersPositionsRepository = unitOfWork.UserPositionRepository;
        }

        public async void Stop()
        {
            await scheduler.Shutdown();
        }

        public async void Start(CancellationToken token)
        {
            var factory = new StdSchedulerFactory();
            scheduler = await factory.GetScheduler(token);

            await scheduler.Start(token);

            var jobAction = new Action(() =>
            {
                var users = userProvider.GetAllUsers();
                if (users == null)
                    return;
                var usersList = users.ToArray();

                var existingPositions = usersPositionsRepository.ReadAll().ToList();
                var positionsToAdd = new List<UserPosition>();

                foreach (var user in usersList)
                {
                    if (existingPositions.Any(x => x.Type == user.Position.Type))
                    {
                        user.Position = existingPositions.First(x => x.Type == user.Position.Type);
                        user.Position.Users.Add(user);
                    }
                    else
                    {
                        user.Position.Users = new List<User> { user };
                        positionsToAdd.Add(user.Position);
                        existingPositions.Add(user.Position);
                    }
                }

                usersPositionsRepository.Create(positionsToAdd);
                usersRepository.Create(usersList);

                unitOfWork.Save();
            });

            IJobDetail jobDetail = JobBuilder.Create<GenericJob>()
                .WithIdentity("FillDate", "DefaultGroup")
                .Build();
            jobDetail.JobDataMap["Action"] = jobAction;

            ITrigger jobTrigger = TriggerBuilder.Create()
                .WithIdentity("FillDate", "DefaultGroup")
                // Think of placing the schedule in application configuration.
                .WithCronSchedule("0 0 20 * * ?")
                .ForJob(jobDetail)
                .Build();
            
            await scheduler.ScheduleJob(jobDetail, jobTrigger, token);

        }
    }
}
