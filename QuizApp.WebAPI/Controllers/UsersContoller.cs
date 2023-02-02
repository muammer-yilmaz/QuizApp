using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Auth.Command.CreateUser;

namespace QuizApp.WebAPI.Controllers
{
    public class UsersContoller : ApiController
    {
        public UsersContoller(IMediator mediator) : base(mediator)
        {

        }
        //[Authorize(AuthenticationSchemes = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
