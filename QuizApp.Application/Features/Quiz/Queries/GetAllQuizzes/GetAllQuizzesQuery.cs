using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes;

public sealed record GetAllQuizzesQuery : IQuery<GetAllQuizzesQueryResponse>
{
    // TODO : in c#11 assign to backing field using "field = value.Trim()"
    private string? _searchText;
    public string? SearchText
    {
        get { return _searchText?.Trim(); } // "?" operatorü null ise hata alınmasını önler.
        set { _searchText = value; }
    }

    public PaginationRequestDto Pagination { get; set; }

    public GetAllQuizzesQuery(string? searchText, PaginationRequestDto pagination)
    {
        SearchText = searchText;
        Pagination = pagination;
    }

    public GetAllQuizzesQuery(PaginationRequestDto pagination)
    {
        Pagination = pagination;
    }

}
