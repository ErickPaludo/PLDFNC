using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models;

namespace WebApiFinanc.Services
{
    public interface IGerenciaGastos
    {
        dynamic Registra(Gastos gasto);
        void Excluir(int id);
        Gastos Update(Gastos gastoModify);
    }
}
