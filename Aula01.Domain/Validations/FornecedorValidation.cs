using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain.Validations
{ 
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo nome precisa ser preenchido.")
                .NotNull().WithMessage("O campo nome não pode ser nulo.")
                .Length(2, 100).WithMessage("O campo nome deve ter entre 2 e 100 caracteres.");
            
        }
    }
}