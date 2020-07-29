using DB.Context;
using DB.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
    public class WorkPlanRepository : AbstractRepository<WorkPlan>
    {
        public WorkPlanRepository(HqrbContext context) : base(context)
        {
        }

        public override DbSet<WorkPlan> GetDbSet()
        {
            throw new NotImplementedException();
        }
    }
}
