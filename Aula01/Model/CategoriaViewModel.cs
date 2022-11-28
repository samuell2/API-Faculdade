
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Aula01.Domain.Enum;

namespace Aula01.Model
{
	public class CategoriaViewModel
	{

		
		public int ID { get; set; }
		
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public bool Ativo { get; set; }

	}
}
