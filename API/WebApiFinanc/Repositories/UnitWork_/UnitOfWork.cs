using WebApiFinanc.Context;
using WebApiFinanc.Repositories.CreditoRepository_;
using WebApiFinanc.Repositories.DebitoRepository_;
using WebApiFinanc.Repositories.UsuarioRepository_;

namespace WebApiFinanc.Repositories.UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUsuarioRepository? _usuRepo;
        private IDebitoRepository? _debRepo;
        private ICreditoRepository? _creRepo;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUsuarioRepository UsuarioRepository { get { return _usuRepo = _usuRepo ?? new UsuarioRepository(_context); } }
        public IDebitoRepository DebitoRepository { get { return _debRepo = _debRepo ?? new DebitoRepository(_context); } }
        public ICreditoRepository CreditoRepository { get { return _creRepo = _creRepo ?? new CreditoRepository(_context); } }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
