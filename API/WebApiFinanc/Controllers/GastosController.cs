using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using WebApiFinanc.Filters.FiltersControllers;
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
        public ActionResult<IEnumerable<Geral>> RetornoGeral(int iduser, [FromQuery] QueryStringParameters geralParameters, [FromQuery] FilterDataParameter dateParam, string? categoria = null)
        {
            if(!_unit.UsuarioRepository.ObjectAny(x => x.UserId == iduser))
            {
                return NotFound("Usuário não encontrado");
            }

            var creditoObjects = _unit.CreditoRepository.GetObjects(x => x.UserId == iduser) ?? _unit.CreditoRepository.Get();
            var debitoObjects = _unit.DebitoRepository.GetObjects(x => x.UserId == iduser) ?? _unit.DebitoRepository.Get(); ;
            var saldoObjects = _unit.SaldoRepository.GetObjects(x => x.UserId == iduser) ?? _unit.SaldoRepository.Get(); ;

            IEnumerable<Geral> geral = (creditoObjects
     .Join(_unit.GastoStatusRepository.Get(),
         gastos => gastos.Id,
         status => status.GPaiId,
         (gastos, status) => new Geral
         {
             GpId = gastos.Id.ToString(),
             Id = status.Id,
             Titulo = gastos.Titulo,
             Decricao = gastos.Descricao,
             Valor = gastos.Valor * -1,
             Dthr = gastos.DthrReg.AddMonths(status.Parcela - 1),
             Parcela = $"{status.Parcela}/{gastos.TotalParcelas}",
             Status = _gerenciamento.DeParaStatus(status.Status),
             Categoria = "Crédito"
         }).Where(x => x.Dthr >= dateParam.DataIni && x.Dthr <= dateParam.DataFim)
     .ToList()).Concat(debitoObjects
                    .Select(gastos => new Geral
                    {
                        Id = gastos.Id,
                        Titulo = gastos.Titulo,
                        Decricao = gastos.Descricao,
                        Valor = gastos.Valor * -1,
                        Dthr = gastos.DthrReg,
                        Parcela = string.Empty,
                        Categoria = "Débito",
                        Status = _gerenciamento.DeParaStatus(gastos.Status)
                    }).Where(x => x.Dthr >= dateParam.DataIni && x.Dthr <= dateParam.DataFim)
                    .ToList())
                .Concat(saldoObjects
                    .Select(gastos => new Geral
                    {
                        Id = gastos.Id,
                        Titulo = gastos.Titulo,
                        Decricao = gastos.Descricao,
                        Valor = gastos.Valor,
                        Dthr = gastos.DthrReg,
                        Parcela = string.Empty,
                        Categoria = "Saldo",
                        Status = _gerenciamento.DeParaStatus(gastos.Status)
                    }).Where(x => x.Dthr >= dateParam.DataIni && x.Dthr <= dateParam.DataFim)
                    .ToList());


            if (!string.IsNullOrEmpty(categoria) && !_gerenciamento.DeParaCategoria(categoria).Equals("Não definido"))
            {
                geral = geral.Where(x => x.Categoria == _gerenciamento.DeParaCategoria(categoria));
            }
            var debitosOrdenados = PagedList<Geral>.TotalPagedList(geral.AsQueryable(), geralParameters.PageNumber, geralParameters.PageSize);

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(new
            {
                debitosOrdenados.TotalCount,
                debitosOrdenados.PageSize,
                debitosOrdenados.CurrentPage,
                debitosOrdenados.TotalPages,
                debitosOrdenados.HasNext,
                debitosOrdenados.HasPrevious
            }));

            return Ok(debitosOrdenados);
        }
        #endregion  
    }
}
