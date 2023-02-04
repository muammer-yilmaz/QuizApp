using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Features.Quiz.Commands.DeleteQuiz;
using QuizApp.Application.Features.Quiz.Commands.UpdateQuiz;
using QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes;
using QuizApp.Application.Features.Quiz.Queries.GetQuizDetails;

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
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetQuizDetails([FromQuery] GetQuizDetailsQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        //[Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateQuizCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var request = new DeleteQuizCommand(id);
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateQuizCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
