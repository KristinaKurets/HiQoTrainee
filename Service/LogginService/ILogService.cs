using System;
using System.Linq;

namespace Service.LogginService
{
    public interface ILogService<TSource> where TSource : class
    {
        IQueryable<TSource> GetLog();
        IQueryable<TSource> GetLog(int number);
        IQueryable<TSource> GetLog(Func<TSource, bool> predicate);
    }
}
