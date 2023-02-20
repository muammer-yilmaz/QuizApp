using System.Reflection;

namespace QuizApp.Persistence;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}
