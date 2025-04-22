using System.Linq.Expressions;
using WebApiFinanc.Models;
using WebApiFinanc.Pagination;
using X.PagedList;

namespace WebApiFinanc.Repositories.Default
{
    public interface IRepositoryDefault<T> where T : class
    {
        Task<IQueryable<T>> Get();
        Task<IEnumerable<T?>> GetObjects(Expression<Func<T, bool>> predicate);
        T? Create(T userobject);
        T? Update(T userobject);
        bool Delete(Expression<Func<T, bool>> predicate);
        bool ObjectAny(Expression<Func<T, bool>> predicate);
        Task<IPagedList<T>> GetWithParameters(IQueryable<T> objeto, QueryStringParameters produtoParameters, Expression<Func<T, int>> ordenation);
    }
}
