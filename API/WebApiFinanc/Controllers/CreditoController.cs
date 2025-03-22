﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Models.DTOs.Debito;
using WebApiFinanc.Repositories.UnitWork;
using WebApiFinanc.Services;

namespace WebApiFinanc.Controllers
{
    [Route("credito")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IGerenciaGastos _gerenciamento;
        private readonly IMapper _mapper;

        public CreditoController(IUnitOfWork unit, ILogger<CreditoController> logger, IGerenciaGastos gerenciamento, IMapper mapper)
        {
            _unit = unit;
            _gerenciamento = gerenciamento;
            _mapper = mapper;
        }

        [HttpGet("retorno")]
        public ActionResult<IEnumerable<CreditoDTO>> RetornaCredito()
        {
            IEnumerable<CreditoDTO> query = from gastos in _unit.CreditoRepository.Get()
                                            join status in _unit.GastoStatusRepository.Get()
                                                on gastos.Id equals status.GPaiId
                                            select new CreditoDTO
                                            {
                                                Id = gastos.Id,
                                                Titulo = gastos.Titulo,
                                                Descricao = gastos.Descricao,
                                                Valor = gastos.Valor,
                                                DthrReg = gastos.DthrReg.AddMonths(status.Parcela - 1),
                                                Parcela = status.Parcela,
                                                TotalParcelas = gastos.TotalParcelas,
                                                Status = status.Status,
                                                UserId = gastos.UserId
                                            };
            return query.ToList();
        }

        [HttpGet("retornafiltrado/{id:int}", Name = "ObterCredito")]
        public ActionResult<IEnumerable<CreditoDTO>> RetornaCredito(int id)
        {
            var credito = _unit.CreditoRepository.GetObjects(x => x.Id == id);
            if (credito is null)
            {
                return NoContent();
            }
            IEnumerable<CreditoDTO> query = from gastos in _unit.CreditoRepository.Get()
                                            join status in _unit.GastoStatusRepository.Get()
                                                on gastos.Id equals status.GPaiId
                                            where gastos.Id == id
                                            select new CreditoDTO
                                            {
                                                Id = gastos.Id,
                                                Titulo = gastos.Titulo,
                                                Descricao = gastos.Descricao,
                                                Valor = gastos.Valor,
                                                DthrReg = gastos.DthrReg.AddMonths(status.Parcela - 1),
                                                Parcela = status.Parcela,
                                                TotalParcelas = gastos.TotalParcelas,
                                                Status = status.Status,
                                                UserId = gastos.UserId
                                            };
            return query.ToList();
        }

        [HttpPost("cadastro")]
        public ActionResult<IEnumerable<Credito>> CadastraCredito([FromBody] Credito credito)
        {
            _gerenciamento.RegistraCredito(credito);
            return new CreatedAtRouteResult("ObterCredito", new { id = credito.Id }, credito);
        }

        [HttpDelete("deleta/{id:int}")]
        public IActionResult Deletar(int id)
        {
            _gerenciamento.Excluir(id, "C");
            return Ok();
        }

        [HttpPatch("alterar/{id}")]
        public ActionResult<CreditoEditDTO> AlterarCredito(int id, JsonPatchDocument<CreditoEditDTO> patchCredito)
        {
            var result = _gerenciamento.UpdateCredito(id, patchCredito);
            return Ok(_mapper.Map<CreditoEditDTO>(result));
        }
    }
}
