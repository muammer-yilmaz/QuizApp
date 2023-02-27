namespace QuizApp.Application.Common.DTOs;

public sealed record CategoryDto
{
    public string Id { get; set; }
    public string CategoryName { get; set; }
}