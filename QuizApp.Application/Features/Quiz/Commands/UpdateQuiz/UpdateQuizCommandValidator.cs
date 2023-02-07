using FluentValidation;

namespace QuizApp.Application.Features.Quiz.Commands.UpdateQuiz;

public class UpdateQuizCommandValidator : AbstractValidator<UpdateQuizCommand>
{
	public UpdateQuizCommandValidator()
	{
		RuleFor(p => p.Title).NotEmpty();
		RuleFor(p => p.Description).NotEmpty();
		RuleFor(p => p.Id).NotEmpty();
	}
}
