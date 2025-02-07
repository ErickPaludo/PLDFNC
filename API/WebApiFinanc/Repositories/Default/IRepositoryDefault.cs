using System.Linq.Expressions;
using WebApiFinanc.Models;

namespace WebApiFinanc.Repositories.Default
{
    public interface IRepositoryDefault<T>
    {
        IEnumerable<T> Get();
        T? GetObjects(Expression<Func<T, bool>> predicate);
        T? Create(T userobject);
        T? Update(T userobject);
        T? Delete(T userobject);
        bool ObjectAny(Expression<Func<T, bool>> predicate);
    }
}
