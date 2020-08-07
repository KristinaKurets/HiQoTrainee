using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DB.Context;
using DB.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Repositories
{
    public interface IUniqueRepositoryTraits<in T> where T : class
    {
        int GetId(T item);
        bool Equals(T item1, T item2);
        void CopyTo(T from, T to);
    }

    public class UniqueRepository<T> : IRepository<T> where T: class
    {
        private readonly IRepository<T> repository;
        private readonly IUniqueRepositoryTraits<T> traits;

        public UniqueRepository(IRepository<T> repository, IUniqueRepositoryTraits<T> traits)
        {
            this.repository = repository;
            this.traits = traits;
        }

        public T Read(Func<T, bool> predicate) => repository.Read(predicate);

        public T Read(params object[] keyValue) => repository.Read(keyValue);

        public T Create(T item)
        {
            T repositoryItem = repository.Read(traits.GetId(item));
            if (repositoryItem == null)
            {
                repository.Create(item);
            }
            else
            {
                if (!traits.Equals(item, repositoryItem))
                {
                    traits.CopyTo(item, repositoryItem);
                    repository.Update(repositoryItem);
                }
            }
            return item;
        }

        public void Create(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Create(item);
            }
        }

        public void Delete(T item) => repository.Delete(item);

        public IQueryable<T> ReadAll(Func<T, bool> predicate) => repository.ReadAll(predicate);

        public IQueryable<T> ReadAll() => repository.ReadAll();

        public void Update(T item) => repository.Update(item);

        public void DeleteAll() => repository.DeleteAll();
        public void Save(string tableName) => repository.Save(tableName);
    }
}
