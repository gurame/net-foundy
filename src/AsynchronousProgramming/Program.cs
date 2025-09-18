using NetFoundy.AsynchronousProgramming;

var topic = args[0];
switch (topic)
{
    case "exceptionsintask":
        await ExceptionsInTask.Run();
        break;  
    default:
        Console.WriteLine("Unknown topic");
        break;
}