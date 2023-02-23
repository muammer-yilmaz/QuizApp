﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Question.Commands.CreateQuestion;
using QuizApp.Application.Features.Question.Commands.DeleteQuestion;
using QuizApp.Application.Features.Question.Commands.UpdateQuestion;
using QuizApp.Application.Features.Question.Queries.GetQuestionList;

namespace QuizApp.WebAPI.Controllers;

public class QuestionsController : ApiController
{
    public QuestionsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<GetQuestionListQueryResponse>> GetQuestionList([FromQuery] string quizId)
    {
        var response = await _mediator.Send(new GetQuestionListQuery(quizId));
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<CreateQuestionCommandResponse>> Create([FromBody] CreateQuestionCommand request)
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
    public async Task<ActionResult<UpdateQuestionCommandResponse>> Update([FromBody] UpdateQuestionCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
