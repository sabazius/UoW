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
            RuleFor(x => x.Name).MaximumLength(25);
            RuleFor(x => x.Name).MinimumLength(5);
            RuleFor(x => x.FacultyId).GreaterThan(0);
            RuleFor(x => x.LectorId).GreaterThan(0);
            RuleFor(x => x.ShortName).MaximumLength(5);
            RuleFor(x => x.ShortName).MinimumLength(2);
        }
    }
}
