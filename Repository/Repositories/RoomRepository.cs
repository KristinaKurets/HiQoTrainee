using DB.Context;
using DB.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
    public class RoomRepository : AbstractRepository<Room>
    {
        public RoomRepository(HqrbContext context) : base(context)
        {
        }

        public override DbSet<Room> GetDbSet()
        {
            return context.Rooms;
        }
    }
}
