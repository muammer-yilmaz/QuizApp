using AutoMapper;
using QuizApp.Application.Features.Auth.Command.CreateUser;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Entities.Identity;

namespace QuizApp.Persistence.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, AppUser>().ReverseMap();
            CreateMap<CreateQuizCommand, Quiz>();
        }
    }
}
