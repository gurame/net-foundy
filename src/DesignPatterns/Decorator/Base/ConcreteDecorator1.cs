namespace NetFoundy.DesignPatterns.Decorator.Base;

class ConcreteDecorator1(Component component) : Decorator(component)
{
    public override void Operation()
    {
        Console.WriteLine("-------- ConcreteDecorator1 --------");
        _component.Operation();
        Console.WriteLine("-------- ConcreteDecorator1 --------");
    }
}