using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;

namespace NetFoundy.AsynchronousProgramming;

static class ExecContext
{
    static readonly AsyncLocal<string> asyncLocal = new();
    public static async Task Run()
    {
        //Assign data controlled by ExecutionContext
        CultureInfo.CurrentCulture = new CultureInfo("es-EP");
        Thread.CurrentPrincipal = new ClaimsPrincipal();
        asyncLocal.Value = "Hello World";

        PrintThreadValues("Main Thread starts");
        
        var mainThreadExecContext = ExecutionContext.Capture() ?? throw new InvalidOperationException("Failed to capture ExecutionContext");
        
        var thread = new Thread(() =>
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-UK");
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("User"), ["Role1"]);
            asyncLocal.Value = "Hello from another thread";
            
            PrintThreadValues("Background Thread after setting its own values");
            
            //Apply the captured ExecutionContext to the new thread
            ExecutionContext.Run(mainThreadExecContext, _ =>
            {
                PrintThreadValues("Same Background Thread after applying Main Thread's ExecutionContext");
            }, null);
        });
        
        //Execute the thread
        thread.Start();
        
        //Wait for the thread to finish
        thread.Join();
        
        //Print Main Thread values again
        PrintThreadValues("Main Thread Values");
        
        await Task.Run(() =>
        {
            PrintThreadValues("Task Thread starts");
        });
        
        // Prevent async/await from automatically flowing the ExecutionContext
        // ExecutionContext.SuppressFlow();
        
        await Task.Run(() =>
        {
            PrintThreadValues("Task Thread after suppressing ExecutionContext flow");
        }).ConfigureAwait(false);

    }

    private static void PrintThreadValues(string title)
    {
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine(title);
        Console.WriteLine("Thread ID: " + Environment.CurrentManagedThreadId);
        Console.WriteLine("Culture: " + CultureInfo.CurrentCulture.Name);
        Console.WriteLine("Principal: " + (Thread.CurrentPrincipal?.GetType()));
        Console.WriteLine("AsyncLocal: " + asyncLocal.Value);
    }
}