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
    [Route("debito")]
    [ApiController]
    public class DebitoController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IGerenciaGastos _gerenciamento;
        private readonly IMapper _mapper;

        public DebitoController(IUnitOfWork unit, ILogger<DebitoController> logger, IGerenciaGastos gerenciamento, IMapper mapper)
        {
            _unit = unit;
            _gerenciamento = gerenciamento;
            _mapper = mapper;
        }


        [Authorize]
        [HttpPost("cadastro")]
        public ActionResult CadastraDebito([FromBody] Debito debito)
        {
            _gerenciamento.RegistraDebito(debito);
            // return CreatedAtAction(nameof(CadastraDebito), new { id = debito.Id }, debito);
            return Ok();
        }
        [Authorize]
        [HttpDelete("deleta/{id:int}")]

        [Authorize]
        public IActionResult Deletar(int id)
        {
            _gerenciamento.Excluir(id, "D");
            return Ok();
        }

        [Authorize]
        [HttpPatch("alterar/{id}")]
        public ActionResult<DebitoEditDTO> AlterarDebito(int id, JsonPatchDocument<DebitoEditDTO> patchDebito)
        {
            var result = _gerenciamento.UpdateDebito(id, patchDebito);
            return Ok(_mapper.Map<DebitoEditDTO>(result));
        }
    }
}
