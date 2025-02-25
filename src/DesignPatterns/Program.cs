using NetFoundy.DesignPatterns.FactoryMethod.Implementation;

var topic = args[0];
switch (topic)
{
    case "factory-method":
        FactoryMethodClient.Run();
        break;
    default:
        Console.WriteLine("Unknown topic");
        break;
}           