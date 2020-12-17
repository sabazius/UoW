using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.Contracts.Requests;

namespace UoW.Validators
{
    public class LectorRequestValidator : AbstractValidator<LectorRequest>
    {
        public LectorRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.FacultyId).GreaterThan(0);
            RuleFor(x => x.FirstName).Must(x => x.Length > 3 && x.Length < 50);
            RuleFor(x => x.LastName).Must(x => x.Length > 3 && x.Length < 50);
        }
    }
}
