using FluentValidation;
using UoW.Models.Contracts.Requests;

namespace UoW.Validators
{
	public class UserPositionRequestValidator : AbstractValidator<UserPositionRequest>
	{
		public UserPositionRequestValidator()
		{
			RuleFor(x => x.Id).GreaterThan(0);
			RuleFor(x => x.Description).MaximumLength(200);
			RuleFor(x => x.PositionName).MaximumLength(30);
		}
	}
}
