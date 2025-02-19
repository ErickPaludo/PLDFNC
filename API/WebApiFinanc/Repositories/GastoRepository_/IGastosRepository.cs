using System.Linq.Expressions;
using WebApiFinanc.Models;
using WebApiFinanc.Repositories.Default;

namespace WebApiFinanc.Repositories.GastoRepository_
{
    public interface IGastosRepository 
    {
        IEnumerable<Gastos> Get();
        Gastos? GetObjects(Expression<Func<Gastos, bool>> predicate);
    }
}
