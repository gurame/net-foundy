using System.Threading.Tasks;

namespace NetFoundy.AsynchronousProgramming;
class ExceptionsInTask
{
    public static async Task Run()
    {
        Task task = Task.Run(() =>
        {
            throw new InvalidOperationException("Something went wrong in the task.");
        });

        try
        {
            await task;
            // task.ContinueWith(t =>
            // {
            //     if (t.IsFaulted && t.Exception != null)
            //     {
            //         if (t.Exception is AggregateException ex)
            //         {
            //             foreach (var innerEx in ex.InnerExceptions)
            //             {
            //                 Console.WriteLine($"Caught exception: {innerEx.Message}");
            //             }
            //         }
            //         else
            //         {
            //             Console.WriteLine($"Task failed with exception: {t.Exception.Message}");
            //         }
            //     }
            // }).Wait();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Caught exception: {ex.Message}");
        }
    }
}