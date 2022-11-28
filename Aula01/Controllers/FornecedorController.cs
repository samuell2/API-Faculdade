using Aula01.Domain;
using Aula01.Domain.Validations;
using Aula01.Domain.Interfaces;
using Aula01.Model;
using Aula01.Utilitarios;
using AutoMapper;
using Aula01.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using Aula01.Services;

namespace Aula01.Controllers
{
	[Route("[controller]")]
	public class FornecedorController : Controller
	{
		private readonly IFornecedorService _fornecedorService;
		public FornecedorController(IFornecedorService fornecedorService)
		{
			_fornecedorService = fornecedorService;

		}

		[HttpPost]
		public async Task<IActionResult> Cadastrar([FromForm] FornecedorViewModel fornecedor)
		{
			try
			{
				if (!ModelState.IsValid) return BadRequest(ModelState);

				await _fornecedorService.Cadastrar(fornecedor);

				return Ok(new { success = true, mensagem = "Cadastrado com sucesso" });
			}
			catch (Exception ex)
			{
				return BadRequest(new { success = false, mensagem = ex.Message });
			}

		}

		[HttpPut]
		[Route("Atualizar")]
		public IActionResult Atualizar(int id)
		{
			_fornecedorService.Atualizar(id);
			return Ok(new { status = 200, message = "Fornecedor atualizado com sucesso!" });
		}

		[HttpGet]
		public IActionResult ObterPorId(int id)
		{
			var pesquisa = _fornecedorService.ObterPorId(id);
			if (pesquisa == null) return NotFound();
			return Ok(
				new
				{
					success = true,
					fornecedor = pesquisa
				}
				);
		}
		[Route("ObterTodos")]
		[HttpGet]
		public IActionResult ObterTodos()
		{
			return Ok(
				new
				{
					success = true,
					listaPRODUTO = _fornecedorService.ObterTodos()
				}
				);
		}
	}
}
