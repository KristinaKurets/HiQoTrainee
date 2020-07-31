using DB.Context;
using DB.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
    public class UserPositionRepository : AbstractRepository<UserPosition>
    {
        public UserPositionRepository(HqrbContext context) : base(context)
        {
        }

        public override DbSet<UserPosition> GetDbSet()
        {
            return context.userPositions;
        }
    }
}
