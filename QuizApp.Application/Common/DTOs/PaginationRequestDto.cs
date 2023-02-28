namespace QuizApp.Application.Common.DTOs;

public class PaginationRequestDto
{
    private int _page;
    public int Page
    {
        get => _page;
        set => _page = value <= 0 ? 1 : value;
    }
    public PageSizeOption PageSize { get; set; }

    public PaginationRequestDto()
    {
        this.Page = 1;
        this.PageSize = PageSizeOption.Ten;
    }

    public PaginationRequestDto(int page = 1, int pageSize = 10)
    {
        Page = page < 1 ? 1 : page;
        PageSize = Enum.IsDefined(typeof(PageSizeOption), pageSize) ? (PageSizeOption)pageSize : PageSizeOption.Ten;
    }
}

public enum PageSizeOption
{
    Ten = 10,
    Twenty = 20,
    Fifty = 50
}
