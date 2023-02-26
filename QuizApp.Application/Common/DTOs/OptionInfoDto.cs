namespace QuizApp.Application.Common.DTOs;

public class OptionInfoDto
{
    public string OptionId { get; set; }
    public string Descripton { get; set; }

}

public class OptionOwnerInfoDto : OptionInfoDto
{
    public bool IsAnswer { get; set; }
}
