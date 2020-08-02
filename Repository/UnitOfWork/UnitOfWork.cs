using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext db;
        //public UnitOfWork() : this(new HqrbContext()) { }

        public UnitOfWork(DbContext dbContext)
        {
            db = dbContext;
        }

        public void Save()
        {
            db.SaveChanges();
        }
        
        private bool disposed = false;
       
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
                
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<TSource> GetRepository<TSource>() where TSource : class
        {
            return (IRepository<TSource>)Activator.CreateInstance(typeof(IRepository<TSource>), db);
        }

    }
}
