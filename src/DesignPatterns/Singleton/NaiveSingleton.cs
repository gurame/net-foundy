
namespace NetFoundy.DesignPatterns.Singleton;
public class NaiveSingleton
{
    private static NaiveSingleton _instance = default!;
    private static readonly Lock _lock = new();
    public static NaiveSingleton Instance
    {
        get
        {
            if (_instance == null) // Double-check locking
            {
                lock (_lock) // Thread-safe
                {
                    _instance ??= new NaiveSingleton();
                }
            }
            return _instance;
        }
    }
    private NaiveSingleton()
    {
        Console.WriteLine("NaiveSingleton instance created");
    }
}