using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs;
using WebApiFinanc.Repositories.UnitWork;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly ILogger<CreditoController> _logger;
        private readonly IMapper _mapper;

        public CreditoController(IUnitOfWork unit, ILogger<CreditoController> logger,IMapper mapper)
        {
            _unit = unit;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("/retornacreditos")]
        public ActionResult<IEnumerable<CreditoDTO>> RetornaCredito()
        {
            var credito = _unit.GastosRepository.Get();
            if (credito.Count() == 0) { return NoContent(); }
            return Ok(_mapper.Map<CreditoDTO>(credito));
        }

        [HttpGet("/selecionacredito/{id:int}", Name = "ObterCredito")]
        public ActionResult<IEnumerable<CreditoDTO>> RetornaCreditos(int id)
        {
            var credito = _unit.GastosRepository.GetObjects(x => x.Id == id);
            if (credito is null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<CreditoDTO>(credito));
        }

        [HttpPost("/cadastracredito")]
        public ActionResult<CreditoDTO> CadastraDebito([FromBody] CreditoDTO creditoDto)
        {
            if (creditoDto is null)
            {
                return BadRequest("Body is null");
            }
            var credito = _unit.GastosRepository.Create(_mapper.Map<Gastos>(creditoDto));
            _unit.Commit();
            return new CreatedAtRouteResult("ObterCredito", new { id = credito.Id }, credito);
        }
        [HttpPatch("/altercredito")]
        public IActionResult AlterarDebito([FromBody] CreditoDTO credito)
        {
            if (credito is null)
            {
                return BadRequest("Body is null");
            }
            if (!_unit.CreditoRepository.ObjectAny(x => x.Id == credito.Id))
            {
                return NotFound();
            }

            _unit.CreditoRepository.Update(credito);
            _unit.Commit();
            return Ok(credito);
        }

        [HttpDelete("/deletecredito/{id:int}")]
        public IActionResult Deletar(int id)   
        {
            if (!_unit.CreditoRepository.ObjectAny(x => x.Id == id))
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
