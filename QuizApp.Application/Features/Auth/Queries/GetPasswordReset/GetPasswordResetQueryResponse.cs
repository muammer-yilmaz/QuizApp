﻿using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.Auth.Queries.GetPasswordReset;

public sealed record GetPasswordResetQueryResponse
{
    public string Message { get; set; } = Messages.PasswordResetMailSent;
}