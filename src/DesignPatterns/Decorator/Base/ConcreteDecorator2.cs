namespace NetFoundy.DesignPatterns.Decorator.Base;

class ConcreteDecorator2(Component component) : Decorator(component)
{
    public override void Operation()
    {
        Console.WriteLine("-------- ConcreteDecorator2 --------");
        _component.Operation();
        Console.WriteLine("-------- ConcreteDecorator2 --------");
    }
}