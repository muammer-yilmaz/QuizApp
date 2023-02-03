using System.Runtime.Serialization;

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
    }
}
