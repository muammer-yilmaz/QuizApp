namespace QuizApp.Application.Common.DTOs
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
