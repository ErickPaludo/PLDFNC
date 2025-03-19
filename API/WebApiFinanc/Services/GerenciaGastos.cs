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
        public GerenciaGastos(IUnitOfWork unit, IMapper mapper)
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
            if (credito.Valor > (decimal)0.01 && credito.ValorIntegral == (decimal)0.01) // Se for inserido somente o valor das parcelas
            {
                credito.ValorIntegral = credito.Valor * credito.TotalParcelas; //vai montar o valor total
            }
            else //se for inserido o valor total
            {
                credito.Valor = credito.ValorIntegral / credito.TotalParcelas; //quebrará o valo em valores de parcela
            }
            credito.DthrReg = credito.DthrReg.AddMonths(1);
            credito.DataVencimento = credito.DthrReg.AddMonths(credito.TotalParcelas - 1);
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
                    DthrReg = credito.DthrReg.AddMonths((i - 1)),
                    DataVencimento = credito.DataVencimento,
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
            var gastobj = (_unit.GastosRepository.GetObjects(x => x.Id.Equals(id) || x.GastoPaiId.Equals(id))).FirstOrDefault();
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
            DateTime dataVencimento = DateTime.Now;
            if (gastoModify.Categoria.Equals("C"))
            {               
                bool somaMeses = false;
                bool atualizadata = false;

                DateTime novaData = gastoModify.DthrReg;

                var listobjoriginal = _unit.GastosRepository.GetObjects(x => x.GastoPaiId == gastoModify.Id);
                var objoriginal = listobjoriginal.FirstOrDefault();
               
                if (objoriginal.TotalParcelas != gastoModify.TotalParcelas)
                {
                    var diferenca = objoriginal.TotalParcelas - gastoModify.TotalParcelas;

                    gastoModify.Valor = gastoModify.ValorIntegral / gastoModify.TotalParcelas;
                    if (diferenca < 0)//Adiciona parcelas
                    {
                        somaMeses = true;
                        diferenca = diferenca * -1;//inverte o valor

                        dataVencimento = objoriginal.DataVencimento.AddMonths(diferenca);
                        DateTime dataRegistro = objoriginal.DataVencimento.AddMonths(1);
                        if (gastoModify.DthrReg != objoriginal.DthrReg)
                        {
                            atualizadata = true;
                            dataVencimento = dataVencimento.AddMonths(objoriginal.TotalParcelas + diferenca - 1);
                            dataRegistro = dataVencimento.AddMonths(-(diferenca - 1));
                        }

                        for (int i = 1; i <= diferenca; i++)
                        {
                            var novocredito = new Gastos
                            {
                                Id = 0,
                                Titulo = gastoModify.Titulo,
                                Descricao = gastoModify.Descricao,
                                Valor = gastoModify.Valor,
                                ValorIntegral = gastoModify.ValorIntegral,
                                DthrReg = dataRegistro,
                                DataVencimento = dataVencimento,
                                TotalParcelas = gastoModify.TotalParcelas,
                                Pago = false,
                                Categoria = gastoModify.Categoria,
                                UserId = gastoModify.UserId,
                                GastoPaiId = gastoModify.Id,
                                Parcela = objoriginal.TotalParcelas + i
                            };
                            _unit.GastosRepository.Create(novocredito);
                             dataRegistro = dataRegistro.AddMonths(1);
                        }
                        _unit.Commit();
                    }
                    else if (diferenca > 0)//diminui parcelas
                    {
                        for (int i = 0; i < diferenca; i++)
                        {
                            _unit.GastosRepository.Delete(x => x.GastoPaiId.Equals(gastoModify.Id) && x.Parcela.Equals(objoriginal.TotalParcelas - i));
                        }
                        _unit.Commit();
                        listobjoriginal = _unit.GastosRepository.GetObjects(x => x.GastoPaiId == gastoModify.Id);
                    }
                }
                foreach (var obj in listobjoriginal)
                {
                    obj.Titulo = gastoModify.Titulo;
                    obj.Descricao = gastoModify.Descricao;
                    obj.Valor = gastoModify.Valor;
                    obj.ValorIntegral = gastoModify.ValorIntegral;
                    if (atualizadata)
                    {
                        novaData = gastoModify.DthrReg.AddMonths(obj.Parcela);
                        obj.DthrReg = novaData;
                    }
                    else
                    {
                        obj.DthrReg = somaMeses ? obj.DthrReg.AddMonths(obj.Parcela) : obj.DthrReg;
                    }

                    obj.DataVencimento = dataVencimento;
                    obj.TotalParcelas = gastoModify.TotalParcelas;
                    obj.Pago = gastoModify.Pago;

                    _unit.GastosRepository.Update(obj);
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
