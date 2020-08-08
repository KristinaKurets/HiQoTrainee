using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Interface
{
    public interface IRepository<TSource> where TSource : class
    {
        IQueryable<TSource> ReadAll(Func<TSource, bool> predicate);

        IQueryable<TSource> ReadAll();

        TSource Read(params object[] keyValue);

        TSource Read(Func<TSource, bool> predicate);

        TSource Create(TSource item);

        void Create(IEnumerable<TSource> range);

        void Update(TSource item);

        void Delete(TSource item);

        void DeleteAll();

        void Save(string tableName);
    }
}
