using DB.Context;
using DB.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.Repositories
{
    public class OrderRepository : AbstractRepository<Order>
    {
        public OrderRepository(HqrbContext context) : base(context)
        {
        }

        public override DbSet<Order> GetDbSet()
        {
            throw new NotImplementedException();
        }
    }
}
