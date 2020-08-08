using System;
using System.Threading.Tasks;
using Quartz;

namespace DbScheduler.Job
{
    public class GenericJob: IJob
    {
        public Action Action { get; set; }

        public async Task Execute(IJobExecutionContext context) =>
            await Task.Run(Action);
        
    }
}
