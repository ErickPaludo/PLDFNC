using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiFinanc.Context;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Models.DTOs.Debito;
using WebApiFinanc.Pagination;
using WebApiFinanc.Repositories.DebitoRepository_;
using WebApiFinanc.Repositories.Default;

namespace WebApiFinanc.Repositories.CreditoRepository_
{
    public class CreditoRepository : RepositoryDefault<Credito>, ICreditoRepository 
    {
        public CreditoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
