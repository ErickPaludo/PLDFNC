﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs;
using WebApiFinanc.Repositories.UnitWork;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitoController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly ILogger<DebitoController> _logger;
        private readonly IMapper _mapper;

        public DebitoController(IUnitOfWork unit, ILogger<DebitoController> logger,IMapper mapper)
        {
            _unit = unit;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("/retornadebitos")]
        public ActionResult<IEnumerable<DebitoDTO>> RetornaDebito()
        {
            var debito = _unit.DebitoRepository.Get();
            if (debito.Count() == 0) { return NoContent(); }
            return Ok(debito);
        }

        [HttpGet("/selecionadebito/{id:int}",Name = "ObterDebito")]
        public ActionResult<IEnumerable<DebitoDTO>> RetornaDebitos(int id)
        {
            var debito = _unit.DebitoRepository.GetObjects(x => x.Id == id);
            if (debito is null)
            {
                return NoContent();
            }

            return Ok(debito);
        }

        [HttpPost("/cadastradebito")]
        public IActionResult CadastraDebito([FromBody] DebitoDTO debito)
        {
            if (debito is null)
            {
                return BadRequest("Body is null");
            }
            _unit.DebitoRepository.Create(debito);
            _unit.Commit();
            return new CreatedAtRouteResult("ObterDebito", new { id = debito.Id }, debito);
        }
        [HttpPatch("/alterdebito")]
        public IActionResult AlterarDebito([FromBody] DebitoDTO debito)
        {
            if(debito is null)
            {
                return BadRequest("Body is null");
            }
            if (!_unit.DebitoRepository.ObjectAny(x => x.Id == debito.Id))
            {
                return NotFound();
            }
            _unit.DebitoRepository.Update(debito);
            _unit.Commit();
            return Ok(debito);
        }
    }
}
