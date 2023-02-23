﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Option.Commands.CreateOption;
using QuizApp.Application.Features.Option.Commands.DeleteOption;
using QuizApp.Application.Features.Option.Commands.UpdateAnswer;
using QuizApp.Application.Features.Option.Commands.UpdateOption;
using QuizApp.Application.Features.Option.Queries.GetOptionList;
using Swashbuckle.AspNetCore.Annotations;

namespace QuizApp.WebAPI.Controllers;

public class OptionsController : ApiController
{
    public OptionsController(IMediator mediator) : base(mediator)
    {
    }

    [SwaggerOperation(Summary = "** this action requires Authentication **")]
    [Authorize]
    [HttpGet("[action]")]
    public async Task<ActionResult<GetOptionListQueryResponse>> GetOptionList([FromQuery] string questionId)
    {
        var response = await _mediator.Send(new GetOptionListQuery(questionId));
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromBody] CreateOptionCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var request = new DeleteOptionCommand(id);
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] UpdateOptionCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateAnswer([FromBody] UpdateAnswerCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
