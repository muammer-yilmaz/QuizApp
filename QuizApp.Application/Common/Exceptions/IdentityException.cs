namespace QuizApp.Application.Common.Exceptions;

public sealed class IdentityException : Exception
{
    public IReadOnlyDictionary<string, string> Errors { get; }

    public IdentityException(IReadOnlyDictionary<string, string> errors)
        : base("Identity Error") => Errors = errors;
}