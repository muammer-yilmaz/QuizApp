namespace QuizApp.Application.Common.Exceptions;

public sealed class ValidationException : Exception
{
    public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
        : base("Validation Failure")
        => ErrorsDictionary = errorsDictionary;

    public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }

}

public sealed class IdentityException : Exception
{
    public IReadOnlyDictionary<string, string> Errors { get; }

    public IdentityException(IReadOnlyDictionary<string, string> errors)
        : base("Identity Error") => Errors = errors;
}