namespace NetFoundy.Concepts;

class Tasks
{
    public static void Run()
    {
        var taskBase = Task.Run(() =>
        {
            Console.WriteLine($"Task Base Thread Id: {Environment.CurrentManagedThreadId}");
            throw new Exception("Task Base Exception");
        })
        .ContinueWith(prevTask =>
        {
            Console.WriteLine($"Task Base Continuation Thread Id: {Environment.CurrentManagedThreadId}");
            Console.WriteLine($"Task Base Continuation Exception: {prevTask.Exception?.Message}");
        },
        TaskContinuationOptions.OnlyOnFaulted);
        taskBase.Wait();
        Console.WriteLine("Task base completed");

        var task1 = Task.Run(() => Console.WriteLine($"Task 1 Thread Id: {Environment.CurrentManagedThreadId}"));
        var task2 = Task.Run(() => Console.WriteLine($"Task 2 Thread Id: {Environment.CurrentManagedThreadId}"));
        var task3 = Task.Run(() => Console.WriteLine($"Task 3 Thread Id: {Environment.CurrentManagedThreadId}"));

        Task.WaitAny(task1, task2, task3);
        Console.WriteLine("All tasks completed");
    }
}