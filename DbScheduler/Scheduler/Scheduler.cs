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

namespace DbScheduler
{
    internal class Scheduler
    {
        private readonly IUserProvider userProvider;
        private readonly IRepository<User> usersRepository;
        private readonly DbContext dbContext;
        private IScheduler scheduler;

        public Scheduler(IUserProvider userProvider, IRepository<User> usersRepository, DbContext dbContext)
        {
            this.userProvider = userProvider;
            this.usersRepository = usersRepository;
            this.dbContext = dbContext;
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
                dbContext.SaveChanges();
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
