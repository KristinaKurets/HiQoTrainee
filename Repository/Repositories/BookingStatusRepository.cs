using DB.Context;
using HQRBDBModel.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
    public class BookingStatusRepository : AbstractRepository<BookingStatus>
    {
        public BookingStatusRepository(HqrbContext context) : base(context)
        {

        }

        public override DbSet<BookingStatus> GetDbSet()
        {
            throw new NotImplementedException();
        }
    }
}
