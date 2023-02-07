using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Auth.Command.CreateUser;
using QuizApp.Application.Features.User.Queries.GetAllUsers;
using QuizApp.Application.Features.User.Queries.GetUser;

namespace QuizApp.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            GetUserQuery query = new(id);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());
            return Ok(response);
        }
    }
}
