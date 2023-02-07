using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, GetAllUsersQueryResponse>
{
    private readonly IUserService _userService;

    public GetAllUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public Task<GetAllUsersQueryResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var result = _userService.GetAllUsers(request);
        return result;
    }
}
