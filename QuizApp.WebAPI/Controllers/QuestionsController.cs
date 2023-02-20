using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Question.Commands.CreateQuestion;
using QuizApp.Application.Features.Question.Commands.DeleteQuestion;
using QuizApp.Application.Features.Question.Commands.UpdateQuestion;

namespace QuizApp.WebAPI.Controllers;

public class QuestionsController : ApiController
{
    public QuestionsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromBody] CreateQuestionCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var request = new DeleteQuestionCommand(id);
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] UpdateQuestionCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
