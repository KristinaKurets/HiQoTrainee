using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using DB.Context;
using DB.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PortalApiCheck.Interfaces;
using Repository.Interface;
using Repository.UnitOfWork;

namespace DbScheduler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly Scheduler scheduler;

        public Worker(ILogger<Worker> logger, IUserProvider userProvider, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            scheduler = new Scheduler(userProvider, unitOfWork);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(() =>
            {
                logger.LogInformation("The service has been started.");
                scheduler.Start(stoppingToken);
            }, stoppingToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                logger.LogInformation("The service has been stopped.");
                scheduler.Stop();
            }, cancellationToken);
        }
    }
}
