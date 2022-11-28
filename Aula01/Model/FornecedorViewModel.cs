
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Aula01.Domain.Enum;

namespace Aula01.Model
{
	public class FornecedorViewModel
	{

		
		public int Id { get; set; }
		
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public string Documento { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public bool Ativo { get; set; }

        [JsonIgnore]
        public string Imagem { get; set; }
		public EnumTipoFornecedor tipoFornecedor {get; set;}
        public IFormFile file { get; set; }
    }
}
