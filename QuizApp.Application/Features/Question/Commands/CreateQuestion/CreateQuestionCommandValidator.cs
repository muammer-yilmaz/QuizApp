using FluentValidation;

namespace QuizApp.Application.Features.Question.Commands.CreateQuestion;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
	public CreateQuestionCommandValidator()
	{
		RuleFor(p => p.Title).NotEmpty();
		RuleFor(p => p.Description).NotEmpty();
		RuleFor(p => p.QuizId).NotEmpty();
	}
}
