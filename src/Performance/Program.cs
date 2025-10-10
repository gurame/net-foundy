using NetFoundy.Performance;
var topic = args[0];
switch (topic)
{
    case "boxing":
        BoxingUnboxing.Run();
        break;
    case "string":
        StringVsStringBuilder.Run();
        break;
    case "empty-array":
        EmptyArrayAllocations.Run();
        break;
    default:
        Console.WriteLine("Unknown topic");
        break;
}