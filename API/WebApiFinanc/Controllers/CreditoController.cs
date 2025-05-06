using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiFinanc.Filters.FiltersControllers;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Models.DTOs.Debito;
using WebApiFinanc.Pagination;
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
        [Authorize]
        [HttpPost("cadastro")]
        public ActionResult<IEnumerable<Credito>> CadastraCredito([FromBody] Credito credito)
        {
            _gerenciamento.RegistraCredito(credito);
            //return CreatedAtAction(nameof(CadastraCredito), new { id = credito.Id }, credito);
            return Ok();
        }
        [Authorize]
        [HttpDelete("deleta/{id:int}")]
        public IActionResult Deletar(int id)
        {
            _gerenciamento.Excluir(id, "C");
            return Ok();
        }
        [Authorize]
        [HttpPatch("alterar/{id}")]
        public ActionResult<CreditoEditDTO> AlterarCredito(int id, JsonPatchDocument<CreditoEditDTO> patchCredito)
        {
            var result = _gerenciamento.UpdateCredito(id, patchCredito);
            return Ok(_mapper.Map<CreditoEditDTO>(result));
        }
        [Authorize]
        [HttpPatch("pagamento/{id}")]
        public ActionResult<CreditoEditDTO> PagaParcela(int id, JsonPatchDocument<CreditoEditDTO> patchCredito)
        {
            _gerenciamento.PagaParcela(id, patchCredito);
            return Ok();
        }
    }
}
