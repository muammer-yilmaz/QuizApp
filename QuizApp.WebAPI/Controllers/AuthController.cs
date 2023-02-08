using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Auth.Commands.ConfirmMail;
using QuizApp.Application.Features.Auth.Commands.Login;

namespace QuizApp.WebAPI.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ConfirmMail([FromQuery]string mail,[FromQuery]string token)
        {
            ConfirmMailCommand request = new(mail, token);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
