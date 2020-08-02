using System;
using System.Linq;

namespace Repository.Interface
{
    public interface IRepository<TSource> where TSource : class
    {
        TSource Read(int id);
        TSource Create(TSource item);
        bool Delete(TSource item);
        IQueryable<TSource> ReadAll(Func<TSource, bool> predicate);
        IQueryable<TSource> ReadAll();
        bool DeleteAll();
    }
}
