using QuizApp.Application.Features.Auth.Command.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Services
{
    public interface IUserService
    {
        Task<string> CreateAsync(CreateUserCommand request);
    }
}
