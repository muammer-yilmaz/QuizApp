using FluentValidation;

namespace QuizApp.Application.Features.User.Commands.UpdateProfile;

public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
	public UpdateProfileCommandValidator()
	{
		RuleFor(p => p.FirstName).NotEmpty().MinimumLength(2).MaximumLength(50);
		RuleFor(p => p.LastName).NotEmpty().MinimumLength(2).MaximumLength(50);
	}
}
