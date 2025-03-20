
using WebApiFinanc.Repositories.GastoRepository_;
using WebApiFinanc.Repositories.GastoStatusRepository_;
using WebApiFinanc.Repositories.UsuarioRepository_;

namespace WebApiFinanc.Repositories.UnitWork
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        IGastosRepository GastosRepository { get; }
        IGastoStatusRepository GastoStatusRepository { get; }
        void Commit();
    }
}
