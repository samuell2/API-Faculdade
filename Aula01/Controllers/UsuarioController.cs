using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Model;
using Aula01.Token;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Aula01.Services;

namespace Aula01.Controllers
{
   // [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;

        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UsuarioViewModel usuarioViewModel)
        {
            try
            {
                var teste = _usuarioService.Authenticate(usuarioViewModel);
                return Ok(new { teste });
            }

            catch
            {
                return BadRequest(new { message = "Usuario ou senha incorreto." });
            }
        }
        
        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(UsuarioViewModel usuario)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

            _usuarioService.Cadastrar(usuario);
			return Ok(new { success = true, mensagem = "Cadastrado com sucesso" });
		}

        [HttpPut]
        public IActionResult Atualizar(int id)
        {
            try
            {
                _usuarioService.Atualizar(id);
                return Ok(new { message = "Usuario alterado com sucesso." });
            }
           
            catch
            {
                return BadRequest(new { message = "Usuario não foi atualizado." });
            }
        }
    }
}
