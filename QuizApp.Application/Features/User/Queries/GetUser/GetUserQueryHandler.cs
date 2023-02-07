using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.User.Queries.GetUser;

public class GetUserQueryHandler : IQueryHandler<GetUserQuery, GetUserQueryResponse>
{
    private readonly IUserService _userService;

    public GetUserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var result = _userService.GetUserById(request);
        return result;
    }
}
