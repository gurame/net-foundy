class Yield
{
    public static void Run()
    {
        // List<int>
        var numbers = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            numbers.Add(i);
        }
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine("-----");
        // IEnumerable
        foreach (var number in GenerateNumbers())
        {
            Console.WriteLine(number);
        }
        Console.WriteLine("-----");
        // IAsyncEnumerable
        RunAsync().GetAwaiter().GetResult();
    }

    private static IEnumerable<int> GenerateNumbers()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return i;
        }
    }

    // IAsyncEnumerable
    public static async Task RunAsync()
    {
        await foreach (var number in GenerateNumbersAsync())
        {
            Console.WriteLine(number);
        }
    }

    private static async IAsyncEnumerable<int> GenerateNumbersAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(100); // Simulate asynchronous work
            yield return i;
        }
    }
}