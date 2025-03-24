using WebApiFinanc.Context;
using WebApiFinanc.Models;
using WebApiFinanc.Repositories.Default;

namespace WebApiFinanc.Repositories.DebitoRepository_
{
    public class DebitoRepository : RepositoryDefault<Debito>, IDebitoRepository
    {
        public DebitoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
