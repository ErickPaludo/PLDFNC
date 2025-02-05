using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApiFinanc.Context;
using WebApiFinanc.Filters;
using WebApiFinanc.Models;
using WebApiFinanc.Repositories;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly ILogger<UsuariosController> _logger;
   
        public UsuariosController(IUsuarioRepository repository, ILogger<UsuariosController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("/retornausers")]
        public ActionResult<IEnumerable<Usuarios>> RetornaUsers()
        {
            return Ok(_repository.GetUsuario());
        }

        [HttpGet("/selecionauser/{id:int}")]
        public ActionResult<IEnumerable<Usuarios>> SelecionaUsers(int id)
        {
            var user = _repository.GetUsers(id);
            if (user is not null)
            {
                return Ok(user);
            }
            else { return NotFound(); }
        }

        [HttpPost("cadastrauser")]
        public IActionResult CadastraUser([FromBody] Usuarios usuarios)
        {
            if (_repository.UserAny(usuarios))
            {
                var msg = $"Usuário {usuarios.FirstName} {usuarios.LastName} já está cadastrado!";
                _logger.LogInformation($"[{DateTime.Now}] - {msg}");
                return Conflict(msg);
            }
           _repository.Create(usuarios);
            _logger.LogInformation($"[{DateTime.Now}] - Usuário {usuarios.FirstName } {usuarios.LastName} /id: {usuarios.UserId} cadastrado!");
            return Ok(usuarios);
        }
        [HttpPatch("alteruser")]
        public IActionResult AlterarUser([FromBody] Usuarios usuarios)
        {
            if (!_repository.UserAny(usuarios))
            { 
                return NotFound("Usuário não encontrado");
            }
            _repository.Update(usuarios);
            _logger.LogInformation($"[{DateTime.Now}] - Usuário {usuarios.FirstName} {usuarios.LastName} /id: {usuarios.UserId} foi alterado!\nBody: {JsonSerializer.Serialize(usuarios)}");
            return Ok(usuarios);
        }
    }
}
