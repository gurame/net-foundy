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
    default:
        Console.WriteLine("Unknown topic");
        break;
}