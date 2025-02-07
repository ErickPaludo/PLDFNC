using Microsoft.EntityFrameworkCore;
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

        T? IRepositoryDefault<T>.GetObjects(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }
        IEnumerable<T> IRepositoryDefault<T>.Get()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }
        bool IRepositoryDefault<T>.ObjectAny(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Any(predicate);
        }
        T? IRepositoryDefault<T>.Create(T userobject)
        {
            _context.Set<T>().Add(userobject);
            return userobject;

        }
        T? IRepositoryDefault<T>.Delete(T userobject)
        {
            _context.Set<T>().Remove(userobject);
            return userobject;
        }
        T? IRepositoryDefault<T>.Update(T userobject)
        {
            _context.Set<T>().Update(userobject);
            return userobject;
        }
    }
}
