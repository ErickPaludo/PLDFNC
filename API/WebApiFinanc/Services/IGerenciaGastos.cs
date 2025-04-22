using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Models.DTOs.Debito;
using WebApiFinanc.Models.DTOs.Saldo_;

namespace WebApiFinanc.Services
{
    public interface IGerenciaGastos
    {
        Credito RegistraCredito(Credito credito);
        Debito RegistraDebito(Debito debito); 
        Saldo RegistraSaldo(Saldo saldo);
        void Excluir(int id,string tipo = "O");
       Task<Gastos> Update(Gastos gastoModify);
        Task<Debito> UpdateDebito(int id, JsonPatchDocument<DebitoEditDTO> debito);
        Task<Credito> UpdateCredito(int id, JsonPatchDocument<CreditoEditDTO> credito);
        Task<Saldo> UpdateSaldo(int id, JsonPatchDocument<SaldoEditDTO> saldo);
       Task PagaParcela(int id, JsonPatchDocument<CreditoEditDTO> parcela);
        string DeParaStatus(string status);   
        string DeParaCategoria(string status);
    }
}
