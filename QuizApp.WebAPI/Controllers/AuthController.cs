using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Auth.Commands.Login;

namespace QuizApp.WebAPI.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
