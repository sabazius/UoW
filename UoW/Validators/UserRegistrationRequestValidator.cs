using FluentValidation;
using UoW.Models.Contracts.Requests;

namespace UoW.Validators
{
	public class UserRegistrationRequestValidator : AbstractValidator<UserRegistrationRequest>
	{
		public UserRegistrationRequestValidator()
		{
			RuleFor(x => x.UserName).EmailAddress();
		}
	}
}
