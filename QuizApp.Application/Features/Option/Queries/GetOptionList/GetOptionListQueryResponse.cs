using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Option.Queries.GetOptionList;

public sealed record GetOptionListQueryResponse
{
    public List<OptionOwnerInfoDto> Options { get; set; }
}