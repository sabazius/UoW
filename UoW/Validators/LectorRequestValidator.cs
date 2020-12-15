using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.Contracts.Requests;

namespace UoW.Validators
{
    class LectorRequestValidator : AbstractValidator<LectorRequest>
    {
        public LectorRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.FacultyId).GreaterThan(0);
            RuleFor(x => x.FirstName).MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.LastName).MinimumLength(3).MaximumLength(20);
        }
    }
}
