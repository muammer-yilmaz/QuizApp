namespace QuizApp.Application.Common.Consts
{
    public static class Messages
    {
        public static string NotFound(string field) => $"{field} not found.";
        public static string CreateSuccessful(string field) => $"{field} Successfully created.";
        public static string UpdateSuccessful(string field) => $"{field} Successfully updated.";
        public static string DuplicateObject(string field) => $"{field} already exists.";

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

    }
}
