namespace NetFoundy.Performance;

public class EmptyArrayAllocations
{
    public static void Run()
    {
        Console.WriteLine("Press ENTER to start test...");
        Console.ReadLine();

        for (int i = 0; i < 10_000_000; i++)
        {
            // Variante 1:
            // var list = new List<int>();
            
            // Variante 2:
            var list = Array.Empty<int>();
            
            if (i % 1_000_000 == 0)
                Console.WriteLine($"Iteration {i:N0}");
        }

        Console.WriteLine("Completed.");
        Thread.Sleep(Timeout.Infinite);
    }
}