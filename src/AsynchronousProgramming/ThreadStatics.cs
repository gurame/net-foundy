namespace NetFoundy.AsynchronousProgramming;

class ThreadStatics
{
    [ThreadStatic]
    private static int _threadSpecificValue;
    
    public static void Run()
    {
        // Initialize value for the main thread
        _threadSpecificValue = 100;
        
        Console.WriteLine($"Main Thread ID: {Environment.CurrentManagedThreadId}, Value: {_threadSpecificValue}");

        // Create and start multiple threads
        Thread thread1 = new Thread(ThreadMethod);
        Thread thread2 = new Thread(ThreadMethod);
        
        thread1.Start();
        thread2.Start();
        
        // Wait for threads to complete
        thread1.Join();
        thread2.Join();
        
        // Main thread value remains unchanged
        Console.WriteLine($"Main Thread ID: {Environment.CurrentManagedThreadId}, Value: {_threadSpecificValue}");
    }

    static void ThreadMethod()
    {
        // Initialize value for this thread
        _threadSpecificValue = Random.Shared.Next(1, 100);
        
        Console.WriteLine($"Thread ID: {Environment.CurrentManagedThreadId}, Value: {_threadSpecificValue}");
    }
}