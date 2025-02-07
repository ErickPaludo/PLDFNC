using WebApiFinanc.Context;
using WebApiFinanc.Models;
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
