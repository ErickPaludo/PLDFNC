using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using WebApiFinanc.Controllers;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Repositories.UnitWork;

namespace WebApiFinanc.Services
{
    public class GerenciaGastos : IGerenciaGastos
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public GerenciaGastos(IUnitOfWork unit,IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public dynamic Registra(Gastos gasto)
        {   
            if (gasto.Categoria.Equals("C"))
            {
                return CadastraCredito(gasto);
            }
            else if (gasto.Categoria.Equals("D"))
            {
                _unit.GastosRepository.Create(gasto);
                _unit.Commit();
                return gasto;
            }
            else
            {
                return gasto;
            }
           
        }
        private IEnumerable<Gastos> CadastraCredito(Gastos credito) 
        {
            List<Gastos> obj = new List<Gastos>();
            int parcelaTotal = credito.TotalParcelas;
            if(credito.Valor > (decimal)0.01 && credito.ValorIntegral == (decimal)0.01) // Se for inserido somente o valor das parcelas
            {
                credito.ValorIntegral = credito.Valor * credito.TotalParcelas; //vai montar o valor total
            }
            else //se for inserido o valor total
            {
                credito.Valor = credito.ValorIntegral / credito.TotalParcelas; //quebrará o valo em valores de parcela
            }         
            credito.DthrReg = credito.DthrReg.AddDays(30);
            credito.Parcela = 1;
            var idcreddito = _unit.GastosRepository.Create(credito);
            _unit.Commit();

            credito.GastoPaiId = idcreddito.Id;

            _unit.GastosRepository.Update(credito);

            obj.Add(credito);

            for (int i = 2; i <= parcelaTotal; i++)
            {
                var creditoSequencial = new Gastos
                {
                    Titulo = credito.Titulo,
                    Descricao = credito.Descricao,
                    Valor = credito.Valor,
                    ValorIntegral = credito.ValorIntegral,
                    DthrReg = credito.DthrReg.AddDays(30 * (i - 1)),
                    DataVencimento = credito.DataVencimento.AddDays(30 * (i - 1)),
                    Parcela = i,
                    TotalParcelas = credito.TotalParcelas,
                    Pago = false,
                    Categoria = credito.Categoria,
                    UserId = credito.UserId,
                    GastoPaiId = idcreddito.Id
                };
                obj.Add(_unit.GastosRepository.Create(creditoSequencial));
                _unit.Commit();
            }
            return obj;
        }
        public void Excluir(int id)
        {
            var gastobj = (_unit.GastosRepository.GetObjects(x => x.Id == id)).FirstOrDefault();
            if (gastobj.Categoria.Equals("D"))
            {
                _unit.GastosRepository.Delete(x => x.Id == gastobj.Id);
            }
            else if (gastobj.Categoria.Equals("C")) 
            {
                _unit.GastosRepository.Delete(x => x.GastoPaiId == id);
            }
            _unit.Commit();
        }

        public Gastos Update(Gastos gastoModify)
        {
            if (gastoModify.Categoria.Equals("C"))
            {
                foreach(var obj in _unit.GastosRepository.GetObjects(x => x.GastoPaiId.Equals(gastoModify.GastoPaiId)))
                {
                    _mapper.Map(gastoModify,obj);
                    _unit.GastosRepository.Update(gastoModify);
                    _unit.Commit();
                }

                return gastoModify;
            }
            else if (gastoModify.Categoria.Equals("D"))
            {
                _unit.GastosRepository.Update(gastoModify);
                return gastoModify;
            }
            else
            {
                return gastoModify;
            }
        }
    }
}
