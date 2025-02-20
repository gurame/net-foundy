using NetFoundy.Concepts;

var topic = args[0];
switch (topic)
{
    case "reftypes":
        ReferenceTypes.Run();
        break;
    case "enums":
        Enums.Run();
        break;
    case "records":
        Records.Run();
        break;
    case "tuples":
        Tuples.Run();
        break;
    case "streams":
        Streams.Run();
        break;
    case "events":
        Events.Run();
        break;
    default:
        Console.WriteLine("Unknown topic");
        break;
}