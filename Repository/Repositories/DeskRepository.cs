using DB.Context;
using DB.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
    public class DeskRepository : AbstractRepository<Desk>
    {
        public DeskRepository(HqrbContext context) : base(context)
        {
        }

        public override DbSet<Desk> GetDbSet()
        {
            return context.Desks;
        }
    }
}
