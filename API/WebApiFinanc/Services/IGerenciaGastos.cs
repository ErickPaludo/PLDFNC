using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Models.DTOs.Debito;

namespace WebApiFinanc.Services
{
    public interface IGerenciaGastos
    {
        Credito RegistraCredito(Credito credito);
        Debito RegistraDebito(Debito debito);
        void Excluir(int id,string tipo = "O");
        Gastos Update(Gastos gastoModify);
        Debito UpdateDebito(int id, JsonPatchDocument<DebitoEditDTO> debito);
    }
}
