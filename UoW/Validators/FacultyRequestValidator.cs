using FluentValidation;
using UoW.Models.Contracts.Requests;

namespace UoW.Validators
{
    public class FacultyRequestValidator : AbstractValidator<FacultyRequest>
    {
        public FacultyRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.Description).MinimumLength(3).MaximumLength(55);
        }
    }
}
