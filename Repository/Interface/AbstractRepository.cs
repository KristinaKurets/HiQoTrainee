using DB.Context;
using Microsoft.EntityFrameworkCore;

namespace Repository.Interface
{
    public abstract class AbstractRepository<TSource> : IRepository<TSource> where TSource: class
    {
        public abstract DbSet<TSource> GetDbSet();

        public AbstractRepository(HqrbContext context)
        {
            this.context = context;
        }

        public TSource Create(TSource item)
        {
            GetDbSet().Add(item);
            context.SaveChanges();
            return item;
        }

        public TSource Read(int id)
        {
            return GetDbSet().Find(id);
        }

        protected HqrbContext context;
    }
}
