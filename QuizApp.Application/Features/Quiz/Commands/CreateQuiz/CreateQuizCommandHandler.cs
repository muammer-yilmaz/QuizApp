using QuizApp.Application.Abstraction.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quiz.Commands.CreateQuiz
{
    internal class CreateQuizCommandHandler : ICommandHandler<CreateQuizCommand, CreateQuizCommandResponse>
    {

        public Task<CreateQuizCommandResponse> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
