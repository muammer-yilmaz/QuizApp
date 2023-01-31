using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;

namespace QuizApp.WebAPI.Controllers
{
    public class QuizzesController : ApiController
    {
        public QuizzesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateQuizCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
