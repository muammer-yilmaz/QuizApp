using AutoMapper;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Category.Commands.CreateCategory;
using QuizApp.Application.Features.Option.Commands.CreateOption;
using QuizApp.Application.Features.Option.Commands.UpdateOption;
using QuizApp.Application.Features.Question.Commands.CreateQuestion;
using QuizApp.Application.Features.Question.Commands.UpdateQuestion;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Features.Quiz.Commands.UpdateQuiz;
using QuizApp.Application.Features.User.Commands.CreateUser;
using QuizApp.Application.Features.User.Commands.UpdateProfile;
using QuizApp.Application.Features.User.Queries.GetUser;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Entities.Identity;

namespace QuizApp.Persistence.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserCommand, AppUser>().ReverseMap();
        CreateMap<UpdateProfileCommand, AppUser>().ReverseMap()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        

        CreateMap<QuizDetailsDto, Quiz>().ReverseMap();
        CreateMap<QuestionsDto, Question>().ReverseMap();
        CreateMap<OptionsDto, Option>().ReverseMap();

        CreateMap<Quiz, QuizInfoDto>().ForMember(x => x.QuizId , opt => opt.MapFrom(x => x.Id));

        CreateMap<AppUser, GetUserQueryResponse>();

        CreateMap<CreateQuizCommand, Quiz>();
        CreateMap<UpdateQuizCommand, Quiz>();

        CreateMap<CreateCategoryCommand, Category>();

        CreateMap<CreateQuestionCommand, Question>();
        CreateMap<UpdateQuestionCommand, Question>();

        CreateMap<CreateOptionDto, Option>();
        CreateMap<CreateOptionCommand, List<Option>>();
        CreateMap<UpdateOptionCommand, Option>();

    }
}
