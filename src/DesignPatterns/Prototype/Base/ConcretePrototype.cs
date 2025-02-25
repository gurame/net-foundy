namespace NetFoundy.DesignPatterns.Prototype.Base;

class ConcretePrototype : IPrototype
{
    public IPrototype Clone()
    {
        return new ConcretePrototype();
    }
}
