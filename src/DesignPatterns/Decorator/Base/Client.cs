namespace NetFoundy.DesignPatterns.Decorator.Base;

class DecoratorClient
{
    public static void Run()
    {
        Component component = new ConcreteDecorator2(new ConcreteDecorator1(new ConcreteComponent()));
        component.Operation();
    }
}