using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.Models.Contracts.Requests;

namespace UoW.Validators
{
    public class SpecialtyRequestValidator : AbstractValidator<SpecialtyRequest>
    {
        public SpecialtyRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
