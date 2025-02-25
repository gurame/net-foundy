namespace NetFoundy.DesignPatterns.Singleton;

public class ProperSingleton
{
    private static readonly Lazy<ProperSingleton> _instance = new(() => new ProperSingleton());
    public static ProperSingleton Instance => _instance.Value;
    private ProperSingleton()
    {
        Console.WriteLine("ProperSingleton instance created");
    }
}