namespace NetFoundy.DesignPatterns.Decorator.Implementation;

class DecoratorClient
{
    public static void Run()
    {
        ITeslaModel3 component = new NineteenInchWheelTeslaDecorator(new RedPaintTeslaDecorator(new BasicTeslaModel3()));
        Console.WriteLine($"Description: {component.GetDescription()}");
        Console.WriteLine($"Price: {component.GetPrice()}");
        Console.WriteLine($"Range: {component.GetRange()}");
    }
}