using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
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

        public void Create(IEnumerable<TSource> range)
        {
            set.AddRange(range);
        }

        public void Delete(TSource item)
        {
            set.Remove(item);
        }

        public void DeleteAll()
        {
            set.RemoveRange(ReadAll().ToList());
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
            return set.AsQueryable();
        }
    }
}
