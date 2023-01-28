using AutoMapper;
using QuizApp.Application.Features.Auth.Command.CreateUser;
using QuizApp.Domain.Entities.Identity;

namespace QuizApp.Persistence.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, AppUser>().ReverseMap();        }
    }
}
