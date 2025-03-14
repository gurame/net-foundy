namespace NetFoundy.DesignPatterns.Bridge.Base;

abstract class Abstraction(Implementor implementor)
{
    protected Implementor Implementor { get; init; } = implementor;
    public abstract void Foo();
}