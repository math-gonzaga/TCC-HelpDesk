using FluentValidation;
using HelpDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Domain.Validations
{
    public class ChamadoValidation : AbstractValidator<Chamado>
    {
        public ChamadoValidation()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .NotNull()
                .Length(3, 200);

        }
    }
}
