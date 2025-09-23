namespace NetFoundy.AsynchronousProgramming;

class StateMachines
{
    public static async Task Run()
    {
        SmLibraryService service = new SmLibraryService(new HttpClient());
        var result =  service.GetLibrariesTask()
            .ContinueWith((x)=>
                {
                    service.GetLibrariesTask();
                },
                CancellationToken.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default
                );
        Console.WriteLine(result);
    }
}