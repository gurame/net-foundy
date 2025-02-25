using NetFoundy.DesignPatterns.AbstractFactory.Implementation;
using NetFoundy.DesignPatterns.FactoryMethod.Implementation;

var topic = args[0];
switch (topic)
{
    case "factory-method":
        FactoryMethodClient.Run();
        break;
    case "abstract-factory":
        AbstractFactoryClient.Run();
        break;
    default:
        Console.WriteLine("Unknown topic");
        break;
}