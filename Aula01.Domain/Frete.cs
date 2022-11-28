using Aula01.Domain.Validations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Aula01.Domain
{
	public class Frete
	{
		protected Frete()
		{

		}

		public bool EhQuebravel { get; set; }
		public double Peso{ get; set; }
        public string UF { get; set; }
        
		public Frete(string uf, double peso, bool quebravel)
		{
			EhQuebravel = quebravel;
			Peso = peso;
			UF = uf;
		}

        internal ValidationResult validationResult { get; set; }

        public bool EhValido()
        {
            validationResult = new FreteValidation().Validate(this);
            return validationResult.IsValid;
        }
	}
}
