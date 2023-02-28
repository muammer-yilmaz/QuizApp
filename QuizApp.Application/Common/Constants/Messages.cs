namespace QuizApp.Application.Common.Constants;

public static class Messages
{
    public static string NotFound(string field) => $"{field} not found.";
    public static string CreateSuccessful(string field) => $"{field} successfully created.";
    public static string UpdateSuccessful(string field) => $"{field} successfully updated.";
    public static string DuplicateObject(string field) => $"{field} already exists.";
    
    public static string UnAuthorizedOperation(string field, string operation) 
        => $"Only the owner of the {field} can perform {operation} action.";

    public static string GenerateRandomImage(string userId)
        => $"http://api.dicebear.com/5.x/identicon/svg?seed={userId}&size=256";
    public const string SwaggerAuthorizeMessage = "** This action requires Authentication **";
    public const string QuestionOptionMaxed = "A Question can have a maximum of 4 options.";
    public const string QuestionOptionAllFalse = "The question must have at least one correct answer.";
    public const string AddFailure = "Add operation failed.";
    public const string PasswordMismatch = "Password does not match.";
    public const string NoAuth = "You are not authorized.";
    public const string EmailConfirmed = "Email successfully confirmed";
    public const string EmailNotConfirmed = "Email is not confirmed.";
    public const string PasswordResetMailSent = "Password reset link sent to your email address.";
    public const string PasswordResetSuccessful = "Password reset is successful.";
    public const string OptionsCanHaveOnlyOneTrueAnswer = "Options can only have one true answer.";
    public const string OptionAlreadyFalse = "This option is already false.";
    public const string OptionAlreadyTrue = "This option is already true.";
    public const string ImageUploadSuccessful = "Image uploaded sucessfully.";
    public const string UnsupportedExtension = "File extension not supported. Only '.jpg','.jpeg','.png' extensions accepted.";
    public const string MaximumFileSizeExceeded = "Maximum allowable file size exceeded. Maximum 2.5 Mb accepted.";
    public const string MinimumOptionsForQuestionLimit = "A question must have minimum of 2 options.";
    public const string OptionTrueAnswerDeletionNotAllowed = "True answer for the question cannot be deleted.";
    public const string MaximumQuestionCountForQuiz = "The maximum number of questions this quiz can have has been exceeded.";
    public const string RefreshTokenExpires = "Refresh token expired";
}
