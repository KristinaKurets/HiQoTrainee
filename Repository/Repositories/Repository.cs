using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Linq;

namespace Repository.Repositories
{
    public class Repository<TSource> : IRepository<TSource> where TSource: class
    {
        private readonly DbContext context;
        private DbSet<TSource> set;

        public Repository(DbContext context)
        {
            this.context = context;
            set = this.context.Set<TSource>();
        }

        public TSource Create(TSource item)
        {
            set.Add(item);
            return item;
        }

        public bool Delete(TSource item)
        {
            int startSize = set.Count();
            set.Remove(item);
            return startSize > set.Count();
        }

        public bool DeleteAll()
        {
            set.RemoveRange(ReadAll().ToList());
            return !set.Any();
        }

        public TSource Read(int id)
        {
            return set.Find(id);
        }

        public IQueryable<TSource> ReadAll(Func<TSource, bool> predicate)
        {
            return set.Where(predicate).AsQueryable();
        }

        public IQueryable<TSource> ReadAll()
        {
            return set;
        }
    }
}
