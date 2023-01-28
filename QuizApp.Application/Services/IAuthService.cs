using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Auth.Commands.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Services
{
    public interface IAuthService
    {
        Task<Token> LoginAsync(LoginCommand request);
    }
}
