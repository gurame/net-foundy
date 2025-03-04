namespace NetFoundy.DesignPatterns.Adapter.Base;

class AdapterClient
{
    public static void Run()
    {
        ITarget target = new Adapter(new Adaptee());
        target.Request();
    }
}