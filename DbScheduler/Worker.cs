using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PortalApiCheck.Interfaces;

namespace DbScheduler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IUserProvider userProvider;
        private readonly Scheduler scheduler;

        public Worker(ILogger<Worker> logger, IUserProvider userProvider)
        {
            this.logger = logger;
            this.userProvider = userProvider;
            scheduler = new Scheduler(userProvider);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            scheduler.Start();
        }
    }
}
