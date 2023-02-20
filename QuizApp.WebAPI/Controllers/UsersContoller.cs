using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Auth.Command.CreateUser;
using QuizApp.Application.Features.User.Commands.UpdatePassword;
using QuizApp.Application.Features.User.Commands.UpdateProfile;
using QuizApp.Application.Features.User.Queries.GetAllUsers;
using QuizApp.Application.Features.User.Queries.GetUser;
using Swashbuckle.AspNetCore.Annotations;

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

        [SwaggerOperation(Summary = "** this action requires Authentication **")]
        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserProfile()
        {
            GetUserQuery query = new();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());
            return Ok(response);
        }

        [SwaggerOperation(Summary = "** this action requires Authentication **")]
        [Authorize]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [SwaggerOperation(Summary = "** this action requires Authentication **")]
        [Authorize]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
