using FluentValidation;
using Aula01.Domain;
namespace Aula01.Domain.Validations
{
    public class FreteValidation : AbstractValidator<Frete>
    {
        public FreteValidation ()
        {
            RuleFor(x => x.Peso)
                .NotEmpty().WithMessage("O peso não pode ser vazio.")
                .NotNull().WithMessage("O peso não pode ser nulo.")
                .GreaterThanOrEqualTo(0).WithMessage("O peso não pode ser negativo.");
            RuleFor(x => x.UF)
                .NotEmpty().WithMessage("UF não pode estar vazio.")
                .NotNull().WithMessage("UF não pode ser nulo.")
                .Length(2).WithMessage("UF deve conter 2 caracteres.");
        }
    }
}