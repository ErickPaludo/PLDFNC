using WebApiFinanc.Context;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs;
using WebApiFinanc.Repositories.Default;

namespace WebApiFinanc.Repositories.CreditoRepository_
{
    public class CreditoRepository : RepositoryDefault<CreditoDTO>, ICreditoRepository
    {
        public CreditoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
