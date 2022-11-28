using Aula01.Domain.Validations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain
{
	public class Produto : Entity
	{
		protected Produto()
		{

		}		

		public string Imagem{get; set;}
		public string Nome { get; set; }
		public decimal Preco { get; set; }
		public int Estoque { get; set; }
		public bool ForadeLinha{get;set;}

	//	public ValidationResult validationResult { get; set; }
		
		public Produto(string nome, decimal preco, int estoque, string imagem, bool foradeLinha)
		{
			Nome = nome;
			Preco = preco;
			Estoque = estoque;
			Imagem = imagem;
			ForadeLinha = foradeLinha;
		}
		//public bool EhValido()
		//{
		//	validationResult = new ProdutoValidation().Validate(this);
		//	return validationResult.IsValid;
		//}
	} 
}
