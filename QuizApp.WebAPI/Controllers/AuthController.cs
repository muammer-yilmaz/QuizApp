using MediatR;

namespace QuizApp.WebAPI.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }
    }
}
