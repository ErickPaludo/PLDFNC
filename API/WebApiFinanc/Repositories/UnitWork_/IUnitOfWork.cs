using WebApiFinanc.Repositories.CreditoRepository_;
using WebApiFinanc.Repositories.DebitoRepository_;
using WebApiFinanc.Repositories.GastoRepository_;
using WebApiFinanc.Repositories.UsuarioRepository_;

namespace WebApiFinanc.Repositories.UnitWork
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        IDebitoRepository DebitoRepository { get; }
        ICreditoRepository CreditoRepository { get; }
        IGastosRepository GastosRepository { get; }
        void Commit();
    }
}
