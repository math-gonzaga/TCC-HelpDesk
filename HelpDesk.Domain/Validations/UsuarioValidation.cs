using FluentValidation;
using HelpDesk.Domain.Models;

namespace HelpDesk.Domain.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(x => x.Tipo)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .Length(3, 50);

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .NotNull()
                .Length(3, 200);

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.SenhaHash)
                .NotEmpty()
                .NotNull();
        }
    }
}