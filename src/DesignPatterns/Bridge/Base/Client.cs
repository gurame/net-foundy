namespace NetFoundy.DesignPatterns.Bridge.Base;

class BridgeClient
{
    public static void Run()
    {
        Implementor implementor = new ConcreteImplementor2();
        Abstraction abstraction = new RefinedAbstraction2(implementor);
        abstraction.Foo();   
    }
}