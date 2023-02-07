using FluentValidation;

namespace QuizApp.Application.Features.Quiz.Commands.CreateQuiz;

public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
{
	public CreateQuizCommandValidator()
	{
		RuleFor(p => p.Title).NotEmpty();
		RuleFor(p => p.Description).NotEmpty();
		
	}
}
