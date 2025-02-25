namespace NetFoundy.DesignPatterns.Prototype.Implementation;

interface IPrototype<T>
{
    T Clone();
}