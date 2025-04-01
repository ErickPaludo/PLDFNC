﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiFinanc.Context;
using WebApiFinanc.Models;

namespace WebApiFinanc.Repositories.Default
{
    public class RepositoryDefault<T> : IRepositoryDefault<T> where T : class
    {
        private readonly AppDbContext _context;

        public RepositoryDefault(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T>? GetObjects(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate).ToList();
        }
        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }
        public bool ObjectAny(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Any(predicate);
        }
        public T? Create(T userobject)
        {
            _context.Set<T>().Add(userobject);
            return userobject;

        }
        public T? Update(T userobject)
        {
            _context.Set<T>().Update(userobject);
            return userobject;
        }

        public bool Delete(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var entity = _context.Set<T>().AsNoTracking().Where(predicate).ToList();
                _context.Set<T>().RemoveRange(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
