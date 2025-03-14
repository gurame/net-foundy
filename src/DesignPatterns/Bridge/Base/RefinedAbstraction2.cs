namespace NetFoundy.DesignPatterns.Bridge.Base;

class RefinedAbstraction2(Implementor implementor) : Abstraction(implementor)
{
    public override void Foo()
    {
        Console.WriteLine("**********"); 
        Implementor.Print();
        Console.WriteLine("**********");
    }
}