using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models.DTOs.Debito;
using WebApiFinanc.Models;
using WebApiFinanc.Repositories.UnitWork;
using WebApiFinanc.Services;
using WebApiFinanc.Models.DTOs.Saldo_;

namespace WebApiFinanc.Controllers
{
    [Route("saldo")]
    [ApiController]
    public class SaldoController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IGerenciaGastos _gerenciamento;
        private readonly IMapper _mapper;

        public SaldoController(IUnitOfWork unit, ILogger<DebitoController> logger, IGerenciaGastos gerenciamento, IMapper mapper)
        {
            _unit = unit;
            _gerenciamento = gerenciamento;
            _mapper = mapper;
        }

        [HttpGet("retorno")]
        public ActionResult<IEnumerable<Saldo>> RetornaSaldo()
        {
            var saldo = _unit.SaldoRepository.Get();
            return Ok(saldo);
        }

        [HttpGet("retornafiltrado/{id:int}", Name = "ObterSaldo")]
        public ActionResult<IEnumerable<Saldo>> RetornaSaldo(int id)
        {
            var saldo = _unit.SaldoRepository.GetObjects(x => x.Id == id);
            if (saldo is null)
            {
                return NoContent();
            }

            return Ok(saldo);
        }

        [HttpPost("cadastro")]
        public ActionResult<IEnumerable<Debito>> CadastraSaldo([FromBody] Saldo saldo)
        {
            _gerenciamento.RegistraSaldo(saldo);
            return new CreatedAtRouteResult("ObterDebito", new { id = saldo.Id }, saldo);
        }

        [HttpDelete("deleta/{id:int}")]
        public IActionResult Deletar(int id)
        {
            _gerenciamento.Excluir(id, "S");
            return Ok();
        }

        [HttpPatch("alterar/{id}")]
        public ActionResult<SaldoEditDTO> AlterarSaldo(int id, JsonPatchDocument<SaldoEditDTO> patchSaldo)
        {
            var result = _gerenciamento.UpdateSaldo(id, patchSaldo);
            return Ok(_mapper.Map<SaldoEditDTO>(result));
        }
    }
}
