using DB.Context;
using DB.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
    public class DeskStatusRepository : AbstractRepository<DeskStatus>
    {
        public DeskStatusRepository(HqrbContext context) : base(context)
        {
        }

        public override DbSet<DeskStatus> GetDbSet()
        {
            throw new NotImplementedException();
        }
    }
}
