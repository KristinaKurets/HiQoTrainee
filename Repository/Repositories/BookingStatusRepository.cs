using DB.Context;
using DB.LookupTable;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
    public class BookingStatusRepository : AbstractRepository<DeskStatusLoockup>
    {
        public BookingStatusRepository(HqrbContext context) : base(context)
        {

        }

        public override DbSet<DeskStatusLoockup> GetDbSet()
        {
            throw new NotImplementedException();
        }
    }
}
