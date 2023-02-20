using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuizApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    protected readonly IMediator _mediator;

    protected ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
