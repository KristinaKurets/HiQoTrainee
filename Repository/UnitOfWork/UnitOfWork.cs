using DB.Context;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private HqrbContext db;
        public UnitOfWork() : this(new HqrbContext()) { }

        public UnitOfWork(HqrbContext dbContext)
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

        public TSource GetRepository<TSource>() where TSource : class
        {
            var result = (TSource)Activator.CreateInstance(typeof(TSource), db);
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
