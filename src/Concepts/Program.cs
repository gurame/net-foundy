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
    case "tasks":
        Tasks.Run();
        break;
    case "polymorphism":
        Polymorphism.Run();
        break;
    case "arrays":
        Arrays.Run();
        break;
    case "bitwise":
        Bitwise.Run();
        break;
    case "operators":
        Operators.Run();
        break;
    case "convertingtypes":
        ConvertingTypes.Run();
        break;
    case "yield":
        Yield.Run();
        break;
    case "lists":
        Lists.Run();
        break;
    default:
        Console.WriteLine("Unknown topic");
        break;
}