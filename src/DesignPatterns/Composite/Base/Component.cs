namespace NetFoundy.DesignPatterns.Composite.Base;

abstract class Component
{
    public abstract void Operation();
    public virtual void Add(Component component) { }
    public virtual void Remove(Component component) { }
    public virtual Component? GetChild(int index) => null;
}