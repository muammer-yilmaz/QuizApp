using AutoMapper;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Auth.Command.CreateUser;
using QuizApp.Application.Features.Category.Commands.CreateCategory;
using QuizApp.Application.Features.Option.Commands.CreateOption;
using QuizApp.Application.Features.Option.Commands.UpdateOption;
using QuizApp.Application.Features.Question.Commands.CreateQuestion;
using QuizApp.Application.Features.Question.Commands.UpdateQuestion;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Features.Quiz.Commands.UpdateQuiz;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Entities.Identity;

namespace QuizApp.Persistence.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, AppUser>().ReverseMap();

            CreateMap<QuizDetails, Quiz>().ReverseMap();
            CreateMap<QuestionsDto, Question>().ReverseMap();
            CreateMap<OptionsDto, Option>().ReverseMap();

            CreateMap<CreateQuizCommand, Quiz>();
            CreateMap<UpdateQuizCommand, Quiz>();

            CreateMap<CreateCategoryCommand, Category>();

            CreateMap<CreateQuestionCommand, Question>();
            CreateMap<UpdateQuestionCommand, Question>();

            CreateMap<CreateOptionCommand, Option>();
            CreateMap<UpdateOptionCommand, Option>();

        }
    }
}
