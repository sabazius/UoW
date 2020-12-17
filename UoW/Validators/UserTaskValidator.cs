using FluentValidation;
using UoW.Models.Tasks;

namespace UoW.Validators
{
	public class UserTaskValidator : AbstractValidator<UserTask>
	{
		public UserTaskValidator()
		{
			RuleFor(x => x.Name).MaximumLength(50);
			RuleFor(x => x.Description).MaximumLength(200);
			RuleFor(x => x.StartDate).LessThan(x => x.EndDate);
		}
	}
}
