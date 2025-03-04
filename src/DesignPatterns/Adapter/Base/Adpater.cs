namespace NetFoundy.DesignPatterns.Adapter.Base;

class Adapter(Adaptee adaptee) : ITarget
{
    public void Request()
    {
        adaptee.SpecificRequest();
    }
}
