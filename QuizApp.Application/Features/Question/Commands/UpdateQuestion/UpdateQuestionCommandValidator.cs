using FluentValidation;

namespace QuizApp.Application.Features.Question.Commands.UpdateQuestion;

public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
{
	public UpdateQuestionCommandValidator()
	{
		RuleFor(p => p.Title).NotEmpty();
		RuleFor(p => p.Descripton).NotEmpty();
		RuleFor(p => p.Id).NotEmpty();
	}
}
