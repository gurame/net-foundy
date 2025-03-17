namespace NetFoundy.DesignPatterns.Decorator.Base;

class ConcreteComponent : Component
{
    public void Operation()
    {
        Console.WriteLine("ConcreteComponent.Operation()");
    }
}