using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Repositories;
using System;
using System.Collections.Generic;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, object> repositories;
        private readonly DbContext db;

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
            repositories ??= new Dictionary<string, object>();
            var type = typeof(TSource).Name;

            if (repositories.ContainsKey(type)) return (IRepository<TSource>) repositories[type];
            var repositoryType = typeof(Repository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TSource)), db);
            repositories.Add(type, repositoryInstance);
            return (IRepository<TSource>)repositories[type];
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
