using Aula01.Domain;
using Aula01.Domain.Interfaces;
using Aula01.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Aula01.Services;
using Microsoft.AspNetCore.Authorization;

namespace Aula01.Controllers
{
	[Route("[controller]")]
	public class CategoriaController : Controller
	{
		private readonly ICategoriaService _categoriaService;
		public CategoriaController(ICategoriaService categoriaService)
		{
			_categoriaService = categoriaService;
		}

		[HttpPost]
		public IActionResult Cadastrar(CategoriaViewModel categoria)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			_categoriaService.Cadastrar(categoria);
			return Ok(new { success = true, mensagem = "Cadastrado com sucesso" });
		}

		[HttpPut]
		[Route("Atualizar")]
		public IActionResult Atualizar(int id)
		{
			_categoriaService.Atualizar(id);
			return Ok( new { status = 200 , message = "Categoria Atualizada com sucesso!"});
		}

		//[Route("Ativar")]
		//[HttpPut]
		//public IActionResult Ativar(int id)
		//{
		//	var categoriaBusca = _categoriaRepository.ObterCategoria(id);

		//	if(categoriaBusca == null)
		//		return NotFound(new { status = 404, message = "Categoria Não encontrada" });

			
		//	_categoriaRepository.Ativar(categoriaBusca);			
			
		//	return Ok( new { status = 200 , message = "Categoria ativada com sucesso!"});

		//}

		//[Route("Inativar")]
		//[HttpPut]
		//public IActionResult Inativar(int id)
		//{
		//	var categoriaBusca = _categoriaRepository.ObterCategoria(id);

		//	if(categoriaBusca == null)
		//		return NotFound(new { status = 404, message = "Categoria Não encontrada" });

			
		//	_categoriaRepository.Inativar(categoriaBusca);			
			
		//	return Ok( new { status = 200 , message = "Categoria inativada com sucesso!"});

		//}
		[HttpGet]
		public IActionResult ObterPorId(int id)
		{
			var pesquisa = _categoriaService.ObterPorId(id);
			if (pesquisa == null) return NotFound();
			return Ok(
				new
				{
					success = true,
					produto = pesquisa
				}
				);
		}
		[Authorize]
		[Route("ObterTodos")]
		[HttpGet]
		public IActionResult ObterTodos()
		{
			return Ok(
				new
				{
					success = true,
					listaPRODUTO = _categoriaService.ObterTodos()
				}
				);
		}

	}
}
