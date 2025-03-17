namespace NetFoundy.DesignPatterns.Decorator.Base;

abstract class Decorator(Component component) : Component
{
    protected readonly Component _component = component;
    public virtual void Operation()
    {
        _component.Operation();
    }
}