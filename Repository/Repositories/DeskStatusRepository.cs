using DB.Context;

using DB.EnttityStatus;
using DB.LookupTable;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
    public class DeskStatusRepository : AbstractRepository<DeskStatusLoockup>
    {
        public DeskStatusRepository(HqrbContext context) : base(context)
        {
        }

        public override DbSet<DeskStatusLoockup> GetDbSet()
        {
            throw new NotImplementedException();
        }
    }
}
