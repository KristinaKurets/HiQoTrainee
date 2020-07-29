using DB.Context;
using DB.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
    public class UserRepository : AbstractRepository<User>
    {
        public UserRepository(HqrbContext context) : base(context)
        {
        }

        public override DbSet<User> GetDbSet()
        {
            throw new NotImplementedException();
        }
    }
}
