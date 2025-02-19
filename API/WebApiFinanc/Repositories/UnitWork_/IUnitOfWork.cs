
using WebApiFinanc.Repositories.GastoRepository_;
using WebApiFinanc.Repositories.UsuarioRepository_;

namespace WebApiFinanc.Repositories.UnitWork
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        IGastosRepository GastosRepository { get; }
        void Commit();
    }
}
