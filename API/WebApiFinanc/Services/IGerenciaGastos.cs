using WebApiFinanc.Models;

namespace WebApiFinanc.Services
{
    public interface IGerenciaGastos
    {
        IEnumerable<Gastos> Registra(Gastos gasto);
    }
}
