using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Quiz.Commands.FinishQuiz;

public class FinishQuizCommandHandler : ICommandHandler<FinishQuizCommand, FinishQuizCommandResponse>
{
    private readonly IQuizService _quizService;
    private readonly IOptionService _optionService;
    private readonly IQuizAttemptService _quizAttemptService;
    private readonly IUserService _userService;

    public FinishQuizCommandHandler(IQuizService quizService, IQuizAttemptService quizAttemptService, IOptionService optionService, IUserService userService)
    {
        _quizService = quizService;
        _quizAttemptService = quizAttemptService;
        _optionService = optionService;
        _userService = userService;
    }

    public async Task<FinishQuizCommandResponse> Handle(FinishQuizCommand request, CancellationToken cancellationToken)
    {
        // Answers compared with the db values and result returned as FinishResultQuestionsDto
        var answerCheckResult = await _optionService.CheckAnswers(request.Quiz.Questions);
        var quizResult = new QuizFinishResultDto()
        {
            QuizId = request.Quiz.QuizId,
            Title = request.Quiz.Title,
            Description = request.Quiz.Description,
            Questions = answerCheckResult,
            CorrectAnswerCount = answerCheckResult.Where(p => p.IsCorrect).Count()
        };

        //this method updates attempt with result to be returned to user as their quiz result
        var quizScore = await _quizService.CalculateScore(request.Quiz.QuizId);

        var userScore = (int) (quizScore / request.Quiz.Questions.Count) * quizResult.CorrectAnswerCount;

        quizResult.Score = userScore;

        await _quizAttemptService.UpdateAttempt(quizResult);
        
        await _userService.UpdateScore(userScore);

        
        return new()
        {
            QuizResult = quizResult,
        };
    }
}
