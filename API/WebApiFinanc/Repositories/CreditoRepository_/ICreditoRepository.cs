using System.Linq.Expressions;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Models.DTOs.Debito;
using WebApiFinanc.Pagination;
using WebApiFinanc.Repositories.Default;

namespace WebApiFinanc.Repositories.CreditoRepository_
{
    public interface ICreditoRepository : IRepositoryDefault<Credito>
    {
    }
}
