using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Repositories;
using System;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext db;
        //public UnitOfWork() : this(new HqrbContext()) { }

        public UnitOfWork(DbContext dbContext)
        {
            db = dbContext;
        }
        
        private bool disposed = false;
       
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
                
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<TSource> GetRepository<TSource>() where TSource : class
        {
            return (IRepository<TSource>)Activator.CreateInstance(typeof(Repository<TSource>), db);
        }

        public void Save()
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                db.Database.ExecuteSqlRaw(string.Format(RepositoryResources.UsersIdentityInsertOn));
                db.SaveChanges();
                db.Database.ExecuteSqlRaw(string.Format(RepositoryResources.UsersIdentityInsertOff));
                transaction.Commit();
            }
        }
    }
}
