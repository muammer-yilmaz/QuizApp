using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Category.Commands.CreateCategory;
using QuizApp.Application.Features.Category.Commands.DeleteCategory;
using QuizApp.Application.Features.Category.Queries.GetAllCategories;
using QuizApp.Persistence;

namespace QuizApp.WebAPI.Controllers;

public class CategoryController : ApiController
{
    private readonly PostgreDbContext context;
    public CategoryController(IMediator mediator, PostgreDbContext context) : base(mediator)
    {
        this.context = context;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<GetAllCategoriesQueryResponse>> GetAll()
    {
        var response = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var request = new DeleteCategoryCommand(id);
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpPost("postgre")]
    public async Task<IActionResult> Ad(string categoryName)
    {
        //using PostgreDbContext context;
        var result = await context.Categories.AddAsync(new Domain.Entities.Category()
        {
            CategoryName = categoryName,
            Id = Guid.NewGuid().ToString()
        });
        //await context.SaveChangesAsync();
        return Ok(result);
    }

}
