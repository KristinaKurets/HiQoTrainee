using DB.Context;
using DB.LookupTable;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
    public class BookingStatusRepository : AbstractRepository<DeskStatusLookup>
    {
        public BookingStatusRepository(HqrbContext context) : base(context)
        {

        }

        public override DbSet<DeskStatusLookup> GetDbSet()
        {
            throw new NotImplementedException();
        }
    }
}
