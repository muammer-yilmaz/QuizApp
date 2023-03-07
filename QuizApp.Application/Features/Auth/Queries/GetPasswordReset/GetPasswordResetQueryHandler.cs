using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Auth.Queries.GetPasswordReset;

public class GetPasswordResetQueryHandler : IQueryHandler<GetPasswordResetQuery, GetPasswordResetQueryResponse>
{
    private readonly IAuthService _authService;

    public GetPasswordResetQueryHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<GetPasswordResetQueryResponse> Handle(GetPasswordResetQuery request, CancellationToken cancellationToken)
    {
        await _authService.GetPasswordReset(request);
        return new();
    }
}
