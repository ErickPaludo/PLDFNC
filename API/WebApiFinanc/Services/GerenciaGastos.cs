using WebApiFinanc.Controllers;
using WebApiFinanc.Models;
using WebApiFinanc.Repositories.UnitWork;

namespace WebApiFinanc.Services
{
    public class GerenciaGastos : IGerenciaGastos
    {
        private readonly IUnitOfWork _unit;
        public GerenciaGastos(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IEnumerable<Gastos> Registra(Gastos gasto)
        {
            List<Gastos> obj = new List<Gastos>();
            if (gasto.Categoria.Equals("C"))
            {
                int parcelaTotal = gasto.TotalParcelas;
                decimal valorParcela = gasto.Valor / gasto.TotalParcelas;

                gasto.Valor = valorParcela;
                gasto.DthrReg = gasto.DthrReg.AddDays(30);
                gasto.Parcela = 1;
                var idcreddito = _unit.GastosRepository.Create(gasto);
                _unit.Commit();
                gasto.GastoPaiId = idcreddito.Id;
                obj.Add(gasto);

                for (int i = 2; i <= parcelaTotal; i++)
                {
                    var creditoSequencial = new Gastos
                    {
                        Titulo = gasto.Titulo,
                        Descricao = gasto.Descricao,
                        Valor = valorParcela,
                        DthrReg = gasto.DthrReg.AddDays(30 * (i - 1)),
                        DataVencimento = gasto.DataVencimento.AddDays(30 * (i - 1)),
                        Parcela = i,
                        Pago = false,
                        Categoria = gasto.Categoria,
                        UserId = gasto.UserId,
                        GastoPaiId = idcreddito.Id
                    };
                    obj.Add(_unit.GastosRepository.Create(creditoSequencial));
                    _unit.Commit();
                }
            }
            return obj;
        }
    }
}
