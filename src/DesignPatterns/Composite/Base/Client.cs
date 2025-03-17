namespace NetFoundy.DesignPatterns.Composite.Base;

class CompositeClient
{
    public static void Run() { 
        Component root = new Composite();
        
        Component leaf = new Leaf();
        root.Add(leaf);

        Component composite = new Composite();
        Component leaf1 = new Leaf();
        composite.Add(leaf1);
        Component leaf2 = new Leaf();
        composite.Add(leaf2);
        root.Add(composite);

        root.Operation();
    }
}