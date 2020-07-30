using DB.Context;
<<<<<<< HEAD
using DB.LookupTable;
=======
using HQRBDBModel.Entity;
>>>>>>> parent of 5a799dd... add DsfaulConncetion string, context
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
<<<<<<< HEAD
    public class BookingStatusRepository : AbstractRepository<DeskStatusLoockup>
=======
    public class BookingStatusRepository : AbstractRepository<BookingStatus>
>>>>>>> parent of 5a799dd... add DsfaulConncetion string, context
    {
        public BookingStatusRepository(HqrbContext context) : base(context)
        {

        }

<<<<<<< HEAD
        public override DbSet<DeskStatusLoockup> GetDbSet()
=======
        public override DbSet<BookingStatus> GetDbSet()
>>>>>>> parent of 5a799dd... add DsfaulConncetion string, context
        {
            throw new NotImplementedException();
        }
    }
}
