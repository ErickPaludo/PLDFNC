using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Models.DTOs.Debito;
using WebApiFinanc.Pagination;
using WebApiFinanc.Repositories.UnitWork;
using WebApiFinanc.Services;

namespace WebApiFinanc.Controllers
{
    [Route("geral")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly ILogger<GastosController> _logger;
        private readonly IGerenciaGastos _gerenciamento;
        private readonly IMapper _mapper;
        public GastosController(IUnitOfWork unit, ILogger<GastosController> logger, IGerenciaGastos gerenciamento, IMapper mapper)
        {
            _unit = unit;
            _logger = logger;
            _gerenciamento = gerenciamento;
            _mapper = mapper;
        }

        #region Retorna todos os gastos
        [HttpGet("retorno")]
        public ActionResult<IEnumerable<Geral>> RetornoGeral([FromQuery] QueryStringParameters geralParameters)
        {
            IQueryable<Geral> geral = (from gastos in _unit.CreditoRepository.Get()
                                        join status in _unit.GastoStatusRepository.Get()
                                            on gastos.Id equals status.GPaiId
                                        select new Geral
                                        {
                                            Titulo = gastos.Titulo,
                                            Decricao = gastos.Descricao,
                                            Valor = gastos.Valor * -1,
                                            Dthr = gastos.DthrReg.AddMonths(status.Parcela - 1),
                                            Parcela = $"{status.Parcela.ToString()}/{gastos.TotalParcelas.ToString()}",
                                            Status = _gerenciamento.DeParaStatus(status.Status),
                                            Categoria = "Crédito"
                                        })
                                          .Concat(from gastos in _unit.DebitoRepository.Get()
                                                  select new Geral
                                                  {
                                                      Titulo = gastos.Titulo,
                                                      Decricao = gastos.Descricao,
                                                      Valor = gastos.Valor * -1,
                                                      Dthr = gastos.DthrReg,
                                                      Parcela = string.Empty,
                                                      Categoria = "Débito",
                                                      Status = _gerenciamento.DeParaStatus(gastos.Status),
                                                  })
                                          .Concat(from gastos in _unit.SaldoRepository.Get()
                                                  select new Geral
                                                  {
                                                      Titulo = gastos.Titulo,
                                                      Decricao = gastos.Descricao,
                                                      Valor = gastos.Valor,
                                                      Dthr = gastos.DthrReg,
                                                      Parcela = string.Empty,
                                                      Categoria = "Saldo",
                                                      Status = _gerenciamento.DeParaStatus(gastos.Status),
                                                  }).AsQueryable();

            var debitosOrdenados = PagedList<Geral>.TotalPagedList(geral, geralParameters.PageNumber, geralParameters.PageSize);

            return Ok(debitosOrdenados);
        }

        [HttpGet("retornafiltrado")]
        public ActionResult<IEnumerable<Gastos>> RetornoGeralFiltro([FromQuery] int iduser, [FromQuery] DateTime dtinicial, [FromQuery] DateTime dtfinal)
        {
            IEnumerable<Geral> geral = (from gastos in _unit.CreditoRepository.Get()
                                        join status in _unit.GastoStatusRepository.Get()
                                            on gastos.Id equals status.GPaiId
                                        where gastos.UserId == iduser && gastos.DthrReg.AddMonths(status.Parcela - 1) >= dtinicial && gastos.DthrReg.AddMonths(status.Parcela - 1) <= dtfinal
                                        select new Geral
                                        {
                                            Titulo = gastos.Titulo,
                                            Decricao = gastos.Descricao,
                                            Valor = gastos.Valor * -1,
                                            Dthr = gastos.DthrReg.AddMonths(status.Parcela - 1),
                                            Parcela = $"{status.Parcela.ToString()}/{gastos.TotalParcelas.ToString()}",
                                            Status = _gerenciamento.DeParaStatus(status.Status),
                                            Categoria = "Crédito"
                                        })
                                        .Concat(from gastos in _unit.DebitoRepository.Get()
                                                where gastos.UserId == iduser && gastos.DthrReg >= dtinicial && gastos.DthrReg <= dtfinal
                                                select new Geral
                                                {
                                                    Titulo = gastos.Titulo,
                                                    Decricao = gastos.Descricao,
                                                    Valor = gastos.Valor * -1,
                                                    Dthr = gastos.DthrReg,
                                                    Parcela = string.Empty,
                                                    Categoria = "Débito",
                                                    Status = _gerenciamento.DeParaStatus(gastos.Status),
                                                })
                                        .Concat(from gastos in _unit.SaldoRepository.Get()
                                                where  gastos.UserId == iduser && gastos.DthrReg >= dtinicial && gastos.DthrReg <= dtfinal
                                                select new Geral
                                                {
                                                    Titulo = gastos.Titulo,
                                                    Decricao = gastos.Descricao,
                                                    Valor = gastos.Valor,
                                                    Dthr = gastos.DthrReg,
                                                    Parcela = string.Empty,
                                                    Categoria = "Saldo",
                                                    Status = _gerenciamento.DeParaStatus(gastos.Status),
                                                });

            return Ok(geral.ToList());
        }
        #endregion  
    }
}
