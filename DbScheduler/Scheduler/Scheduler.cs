using System;
using System.Collections.Generic;
using System.Text;
using DbScheduler.Job;
using PortalApiCheck.Core;
using PortalApiCheck.Interfaces;
using Quartz;
using Quartz.Impl;

namespace DbScheduler
{
    internal class Scheduler
    {
        private readonly IUserProvider userProvider;
        private IScheduler scheduler;

        public Scheduler(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        public async void Start()
        {
            var factory = new StdSchedulerFactory();
            scheduler = await factory.GetScheduler();

            await scheduler.Start();

            IJobDetail jobDetail = JobBuilder.Create<GenericJob>()
                .WithIdentity("FillDate", "DefaultGroup")
                .Build();
            jobDetail.JobDataMap["Action"] = new Action(() =>
            {
                //Action for filling date in DB
                var users = userProvider.GetAllUsers();

            });
            

            ITrigger jobTrigger = TriggerBuilder.Create()
                .WithIdentity("FillDate", "DefaultGroup")
                .WithCronSchedule("0 0 20 * * ?")
                .ForJob(jobDetail)
                .Build();
            
            await scheduler.ScheduleJob(jobDetail, jobTrigger);

        }
    }
}
