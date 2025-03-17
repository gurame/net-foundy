namespace NetFoundy.DesignPatterns.Composite.Base;

class Leaf : Component
{
    public override void Operation()
    {
        Console.WriteLine("Leaf operation");
    }
}