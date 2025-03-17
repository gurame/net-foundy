namespace NetFoundy.DesignPatterns.Facade.Base;

class Facade(Class1 class1)
{
    public void Operation1()
    {
        class1.Operation2();
        Class2 class2 = new Class2();
        class2.Operation3();
        Class4 class4 = new Class4();
        class4.Operation5();
        Class3 class3 = new Class3(class4);
        class3.Operation4(class2);
        Console.WriteLine("Operation1 from Facade");
    }
}