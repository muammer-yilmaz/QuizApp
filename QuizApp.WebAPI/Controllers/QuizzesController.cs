using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Features.Quiz.Commands.DeleteQuiz;
using QuizApp.Application.Features.Quiz.Commands.UpdateQuiz;
using QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes;
using QuizApp.Application.Features.Quiz.Queries.GetQuizDetails;
using QuizApp.Application.Repositories;
using QuizApp.Persistence.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace QuizApp.WebAPI.Controllers
{
    public class QuizzesController : ApiController
    {
        private readonly IQuizReadRepository _quizReadRepository;
        public QuizzesController(IMediator mediator, IQuizReadRepository quizReadRepository) : base(mediator)
        {
            _quizReadRepository = quizReadRepository;
        }

        [HttpGet("[action]")]
        [SwaggerOperation(Summary = "** Pagination **" )]
        public async Task<IActionResult> GetQuizList([FromQuery] PaginationRequestDto pagination)
        {
            GetAllQuizzesQuery query = new(String.Empty,pagination);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("[action]")]
        [SwaggerOperation(Summary = "** Pagination **")]
        public async Task<IActionResult> SearchQuiz([FromQuery] string search, [FromQuery] PaginationRequestDto pagination)
        {
            GetAllQuizzesQuery query = new(search, pagination);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetQuizDetails([FromQuery] GetQuizDetailsQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize]
        [SwaggerOperation(Summary = "** this action requires Authentication **")]
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

        [HttpGet("GetQuizValuesFromDb")]
        [SwaggerOperation(Summary ="This method queries all fields of a single quiz from db")]
        public async Task<IActionResult> GetValues(string id)
        {
            var query = _quizReadRepository.GetWhere(p => p.Id == id);
            var result = await query.Include(p => p.Questions).ThenInclude(p => p.Options).FirstOrDefaultAsync();

            return Ok(result);
        }
    }
}
