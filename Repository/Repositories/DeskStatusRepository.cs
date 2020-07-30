using DB.Context;
<<<<<<< HEAD

using DB.EnttityStatus;
using DB.LookupTable;
=======
using DB.Entity;
>>>>>>> parent of 5a799dd... add DsfaulConncetion string, context
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
<<<<<<< HEAD
    public class DeskStatusRepository : AbstractRepository<DeskStatusLoockup>
=======
    public class DeskStatusRepository : AbstractRepository<DeskStatus>
>>>>>>> parent of 5a799dd... add DsfaulConncetion string, context
    {
        public DeskStatusRepository(HqrbContext context) : base(context)
        {
        }

<<<<<<< HEAD
        public override DbSet<DeskStatusLoockup> GetDbSet()
=======
        public override DbSet<DeskStatus> GetDbSet()
>>>>>>> parent of 5a799dd... add DsfaulConncetion string, context
        {
            throw new NotImplementedException();
        }
    }
}
