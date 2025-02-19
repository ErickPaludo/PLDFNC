using WebApiFinanc.Context;
using WebApiFinanc.Repositories.GastoRepository_;
using WebApiFinanc.Repositories.UsuarioRepository_;

namespace WebApiFinanc.Repositories.UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUsuarioRepository? _usuRepo;
        private IGastosRepository? _gastosRepo;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUsuarioRepository UsuarioRepository { get { return _usuRepo = _usuRepo ?? new UsuarioRepository(_context); } }
        public IGastosRepository GastosRepository { get { return _gastosRepo = _gastosRepo ?? new GastosRepository(_context); } }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
