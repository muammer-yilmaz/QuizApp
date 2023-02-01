﻿using FluentValidation;
using QuizApp.Application.Features.Auth.Command.CreateUser;

namespace QuizApp.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(p => p.EMail).NotEmpty().EmailAddress();
            RuleFor(p => p.Password).NotEmpty().MinimumLength(6).MaximumLength(50);
        }
    }
}