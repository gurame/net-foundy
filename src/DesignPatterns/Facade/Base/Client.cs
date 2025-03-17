namespace NetFoundy.DesignPatterns.Facade.Base;

class FacadeClient
{
    public static void Run()
    {
        Class1 class1 = new Class1();
        Facade facade = new Facade(class1);
        facade.Operation1();
    }
}