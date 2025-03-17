namespace NetFoundy.DesignPatterns.Composite.Base;

class Composite : Component
{
    private readonly List<Component> _children = [];
    public override void Add(Component component)
    {
        _children.Add(component);
    }
    public override void Remove(Component component)
    {
        _children.Remove(component);
    }
    public override Component? GetChild(int index)
    {
        if (index < 0 || index >= _children.Count)
        {
            return null;
        }
        
        return _children[index];
    }
    public override void Operation()
    {
        foreach (var child in _children)
        {
            child.Operation();
        }
    }
}