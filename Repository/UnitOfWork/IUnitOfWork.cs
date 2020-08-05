﻿using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TSource> GetRepository<TSource>() where TSource : class;
        void Save();
    }
}
