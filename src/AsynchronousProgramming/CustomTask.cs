namespace NetFoundy.AsynchronousProgramming;

class CustomTask
{
    public static async Task Run()
    {
        Console.WriteLine("Main Thread ID: " + Environment.CurrentManagedThreadId);
        
        GurameTask.Run(()=>
        {
            Console.WriteLine("Hello from GurameTask! using Thread ID: " + Environment.CurrentManagedThreadId);
            Thread.Sleep(2000);
        }).Wait();
        
        await GurameTask.Run(()=>
        {
            Console.WriteLine("Hello from GurameTask with await! using Thread ID: " + Environment.CurrentManagedThreadId);
            Thread.Sleep(2000);
        });
        
        GurameTask.Delay(TimeSpan.FromSeconds(2)).Wait();
        
        var task = GurameTask.Run(() =>
        {
            Console.WriteLine("GurameTask Thread ID: " + Environment.CurrentManagedThreadId);
            Thread.Sleep(2000);
        });

        task.ContinueWith(() =>
        {
            Console.WriteLine("ContinueWith Thread ID: " + Environment.CurrentManagedThreadId);
        });

        while (!task.Completed)
        {
            Console.WriteLine("Waiting for task to complete...");
            await Task.Delay(500);
        }

        Console.WriteLine("GurameTask is completed.");
    }
}