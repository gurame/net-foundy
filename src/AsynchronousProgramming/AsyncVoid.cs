using AsyncAwaitBestPractices;

namespace NetFoundy.AsynchronousProgramming;

public class AsyncVoid
{
    public AsyncVoid()
    {
        //MyAsyncVoidMethod();
        MyTask().SafeFireAndForget(x=> Console.WriteLine(x.Message));
    }
    async void MyAsyncVoidMethod()
    {
        await MyTask();
        throw new Exception("Async void");
    }
    async Task MyTask()
    {
        await Task.Delay(1000);
        Console.WriteLine("Async void method completed.");
        throw new Exception("Error on Async Task");
    }
}

