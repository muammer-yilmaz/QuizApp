using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Auth.Commands.ConfirmMail;
using QuizApp.Application.Features.Auth.Commands.Login;
using QuizApp.Application.Features.Auth.Commands.ResetPassword;
using QuizApp.Application.Features.Auth.Queries.GetPasswordReset;

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
        public async Task<IActionResult> ConfirmMail([FromQuery] string email, [FromQuery] string token)
        {
            ConfirmMailCommand request = new(email, token);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> PasswordResetMail([FromQuery] string email)
        {
            GetPasswordResetQuery request = new(email);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword([FromQuery] string email, [FromQuery] string token, [FromBody] NewPasswordDto newPassword)
        {
            ResetPasswordCommand request = new(email, token, newPassword.NewPassword);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
    public sealed record NewPasswordDto(
        string NewPassword
    );
}
