using System.Linq.Expressions;
using WebApiFinanc.Models;

namespace WebApiFinanc.Repositories.Default
{
    public interface IRepositoryDefault<T>
    {
        IEnumerable<T> Get();
        IEnumerable<T>? GetObjects(Expression<Func<T, bool>> predicate);
        T? Create(T userobject);
        T? Update(T userobject);
        bool Delete(Expression<Func<T, bool>> predicate);
        bool ObjectAny(Expression<Func<T, bool>> predicate);
    }
}
