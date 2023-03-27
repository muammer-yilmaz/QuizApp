namespace QuizApp.Application.Common.DTOs;

public class OptionInfoDto
{
    public string OptionId { get; set; }
    public string Description { get; set; }

}

public class OptionOwnerInfoDto : OptionInfoDto
{
    public bool IsAnswer { get; set; }
}
