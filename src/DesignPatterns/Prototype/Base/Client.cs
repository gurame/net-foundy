namespace NetFoundy.DesignPatterns.Prototype.Base;

public class PrototypeClient
{
    public static void Run()
    {
        var prototype = new ConcretePrototype();
        var clone = prototype.Clone();
    }
}