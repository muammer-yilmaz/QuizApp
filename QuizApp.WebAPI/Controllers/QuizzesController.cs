using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Features.Quiz.Commands.DeleteQuiz;
using QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes;

namespace QuizApp.WebAPI.Controllers
{
    public class QuizzesController : ApiController
    {
        public QuizzesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllQuizzesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateQuizCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(DeleteQuizCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
