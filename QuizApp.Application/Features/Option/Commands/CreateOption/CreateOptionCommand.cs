﻿using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Domain.Entities;

namespace QuizApp.Application.Features.Option.Commands.CreateOption
{
    public sealed record CreateOptionCommand(
        string QuestionId,
        string Description,
        bool IsAnswer
        ) : ICommand<CreateOptionCommandResponse>;
}
