using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Models.DTOs.Debito;
using WebApiFinanc.Repositories.UnitWork;
using WebApiFinanc.Services;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet("/geral/retorno")]
        public ActionResult<IEnumerable<Gastos>> RetornoGeral()
        {
            var gasto = _unit.GastosRepository.Get();
            if (gasto.Count() == 0) { return NoContent(); }
            return Ok(gasto);
        }

        [HttpGet("/geral/retornafiltrado/{id:int}", Name = "ObterGasto")]
        public ActionResult<IEnumerable<Gastos>> RetornoGeralFiltro(int id)
        {
            var gasto = _unit.GastosRepository.GetObjects(x => x.Id == id);
            if (gasto is null)
            {
                return NoContent();
            }

            return Ok(gasto);
        }
        #endregion  

        #region Retorna Credito
        [HttpGet("/credito/retorno")]
        public ActionResult<IEnumerable<CreditoDTO>> RetornaCredito()
        {
            var gasto = _unit.GastosRepository.GetObjects(x => x.Categoria.Equals("C") && x.Categoria.Equals("C"));
            return Ok(_mapper.Map<List<CreditoDTO>>(gasto));
        }

        [HttpGet("/credito/retornafiltrado/{id:int}")]
        public ActionResult<IEnumerable<Gastos>> RetornaCreditos(int id)
        {
            var gasto = _unit.GastosRepository.GetObjects(x => x.GastoPaiId == id);
            if (gasto is null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<List<CreditoDTO>>(gasto));
        }
        #endregion

        #region Retorna Debito
        [HttpGet("/debito/retorno")]
        public ActionResult<IEnumerable<DebitoDTO>> RetornaDebito()
        {
            var gasto = _unit.GastosRepository.GetObjects(x => x.Categoria.Equals("D") && x.Categoria.Equals("D"));
            return Ok(_mapper.Map<List<DebitoDTO>>(gasto));
        }

        [HttpGet("/debito/retornafiltrado/{id:int}")]
        public ActionResult<IEnumerable<DebitoDTO>> RetornaDebitos(int id)
        {
            var gasto = _unit.GastosRepository.GetObjects(x => x.Id == id && x.Categoria.Equals("D"));
            if (gasto is null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<CreditoDTO>(gasto));
        }
        #endregion

        [HttpPost("/cadastragasto")]
        public ActionResult<IEnumerable<Gastos>> CadastraDebito([FromBody] Gastos gasto)
        {
            if (gasto is null)
            {
                return BadRequest("Body is null");
            }
            var obj = _gerenciamento.Registra(gasto);
            
            return new CreatedAtRouteResult("ObterGasto", new { id = gasto.Id }, gasto);
        }

        [HttpPatch("/credito/alterar/{id}")]
        public ActionResult<CreditoEditDTO> AlterarCredito(int id,JsonPatchDocument<CreditoEditDTO> patchCredito)
        {
            if (patchCredito is null || id <= 0)
            {
                return BadRequest("Body is null");
            }
            if (!_unit.GastosRepository.ObjectAny(x => x.Id == id))
            {
                return NotFound();
            }

            var gasto = _unit.GastosRepository.GetObjects(x => x.Id == id && x.Categoria.Equals("C")).FirstOrDefault();
            if (gasto is null)
                return NotFound("Id não encontrado!");

            var gastoDTO = _mapper.Map<CreditoEditDTO>(gasto);
            patchCredito.ApplyTo(gastoDTO, ModelState);

            if (!ModelState.IsValid && !TryValidateModel(gastoDTO))
                return BadRequest(ModelState);


            _mapper.Map(gastoDTO, gasto); //Faz um marge entre os dois objetos
            _gerenciamento.Update(gasto);

            _unit.Commit();
            return Ok(_mapper.Map<CreditoEditDTO>(gasto));
        }

        [HttpPatch("/debito/alterar/{id}")]
        public ActionResult<CreditoEditDTO> AlterarDebito(int id, JsonPatchDocument<DebitoEditDTO> patchDebito)
        {
            if (patchDebito is null || id <= 0)
            {
                return BadRequest("Body is null");
            }
            if (!_unit.GastosRepository.ObjectAny(x => x.Id == id))
            {
                return NotFound();
            }

            var gasto = _unit.GastosRepository.GetObjects(x => x.Id == id && x.Categoria.Equals("D")).FirstOrDefault();

            if (gasto is null)
                return NotFound("Id não encontrado!");

            var gastoDTO = _mapper.Map<DebitoEditDTO>(gasto);

            patchDebito.ApplyTo(gastoDTO, ModelState);

            if (!ModelState.IsValid && !TryValidateModel(gastoDTO))
                return BadRequest(ModelState);


            _mapper.Map(gastoDTO, gasto); //Faz um marge entre os dois objetos
            _gerenciamento.Update(gasto);

            _unit.Commit();
            return Ok(_mapper.Map<CreditoEditDTO>(gasto));
        }

        [HttpDelete("/deletagasto/{id:int}")]
        public IActionResult Deletar(int id)
        {
            if (!_unit.GastosRepository.ObjectAny(x => x.Id.Equals(id) || x.GastoPaiId.Equals(id)))
            {
                return NotFound();
            }
            _gerenciamento.Excluir(id);
            _unit.Commit();
            return Ok();
        }
    }
}
