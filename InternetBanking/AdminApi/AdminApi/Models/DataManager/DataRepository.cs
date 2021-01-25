﻿using AdminApi.Data;
using AdminApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdminApi.Models.DataManager
{
    public abstract class DataRepository<TEntity, TKey> : IDataRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly McbaContext _context;

        public DataRepository(McbaContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}
