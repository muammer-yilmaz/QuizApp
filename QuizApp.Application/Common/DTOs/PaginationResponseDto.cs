namespace QuizApp.Application.Common.DTOs;

public sealed record PaginationResponseDto<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public T Records { get; set; }
}
