using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        TSource GetRepository<TSource>() where TSource : class;
        void Save();
    }
}
