using NetFoundy.DesignPatterns.AbstractFactory.Implementation;
using NetFoundy.DesignPatterns.Builder.Step;
using NetFoundy.DesignPatterns.FactoryMethod.Implementation;
using NetFoundy.DesignPatterns.Prototype.Implementation;

var topic = args[0];
switch (topic)
{
    case "factory-method":
        FactoryMethodClient.Run();
        break;
    case "abstract-factory":
        AbstractFactoryClient.Run();
        break;
    case "prototype":
        PrototypeClient.Run();
        break;
    case "builder":
        StepBuilderClient.Run();
        break;
    default:
        Console.WriteLine("Unknown topic");
        break;
}