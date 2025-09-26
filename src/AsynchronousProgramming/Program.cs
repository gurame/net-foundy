using NetFoundy.AsynchronousProgramming;

var topic = args.Length > 0 ? args[0] : "statemachines";
switch (topic)
{
    case "exceptionsintask":
        await ExceptionsInTask.Run();
        break;
    case "statemachines":
        await StateMachines.Run();
        break;
    case "customtask":
        await CustomTask.Run();
        break;
    case "asyncvoid":
        var asyncVoid = new AsyncVoid();
        Console.ReadKey();
        break;
    case "threadstatics":
        ThreadStatics.Run();
        break;
    case "execcontext":
        await ExecContext.Run();
        Console.ReadKey();
        break;
    default:
        Console.WriteLine("Unknown topic");
        break;
}