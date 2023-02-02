using System.Runtime.Serialization;

namespace QuizApp.Application.Common.Consts
{
    public static class Messages
    {
        public static string NotFound(string field) => $"{field} not found";
        public static string CreateSuccessful(string field) => $"{field} Successfully created ";
        public static string DuplicateObject(string field) => $"{field} already exists";

        public const string QuestionOptionMaxed = "A Question can have a maximum of 4 options";
        public const string QuestionOptionAllFalse = "The question must have at least one correct answer.";
        internal const string QuizAdded = "Quiz successfully added";
        public const string AddFailure = "Add operation failed";
        public const string EmailDuplicated = "Email address already registered";
        public const string UserNameDuplicated = "Username already registered";
        internal const string CreateUserSuccessful = "User successfully created";
        internal const string CreateCategorySuccessful = "Category successfully created";
    }
}
