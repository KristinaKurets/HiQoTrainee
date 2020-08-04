using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DB.Entity;
using DbScheduler.Job;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUnitOfWork unitOfWork;
        private IScheduler scheduler;

        public Scheduler(IUserProvider userProvider, IUnitOfWork unitOfWork)
        {
            this.userProvider = userProvider;
            this.usersRepository = new UniqueUserRepository(unitOfWork.GetRepository<User>());
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

            IJobDetail jobDetail = JobBuilder.Create<GenericJob>()
                .WithIdentity("FillDate", "DefaultGroup")
                .Build();
            jobDetail.JobDataMap["Action"] = new Action(() =>
            {
                IEnumerable<User> users = userProvider.GetAllUsers();
                usersRepository.Create(users);
                unitOfWork.Save();
            });

            ITrigger jobTrigger = TriggerBuilder.Create()
                .WithIdentity("FillDate", "DefaultGroup")
                // Think of placing the schedule in application configuration.
                .WithCronSchedule("0 43 12 * * ?")
                .ForJob(jobDetail)
                .Build();
            
            await scheduler.ScheduleJob(jobDetail, jobTrigger, token);

        }
    }
}
