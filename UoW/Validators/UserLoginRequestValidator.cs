using FluentValidation;
using UoW.Models.Contracts.Requests;

namespace UoW.Validators
{
	public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
	{
		public UserLoginRequestValidator()
		{
			RuleFor(x => x.Username).EmailAddress();
		}
	}
}
