using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Aula01.Model
{
    public class FreteViewModel
    {
        [JsonIgnore]
        [Range(0, double.MaxValue, ErrorMessage = "Valor de {0} nao pode ser negativo.")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Peso{get; set;}

        [StringLength(2, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 2)]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UF{get; set;}
        public bool EhQuebravel{get; set;}
    }
}