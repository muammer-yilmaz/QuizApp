using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Features.Category.Commands.CreateCategory;
using QuizApp.Application.Features.Category.Commands.DeleteCategory;
using QuizApp.Application.Features.Category.Queries.GetAllCategories;

namespace QuizApp.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand request)
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

    }
}
