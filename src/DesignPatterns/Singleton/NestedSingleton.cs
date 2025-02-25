namespace NetFoundy.DesignPatterns.Singleton;

public sealed class NestedSingleton
{
    public static string ClassName;
    public static NestedSingleton Instance => Nested.Instance;

    private class Nested
    {
        static Nested()
        {
        }
        internal static readonly NestedSingleton Instance = new();
    }
    private NestedSingleton()
    {

    }
    static NestedSingleton()
    {
        ClassName = "NestedSingleton";
    }
}