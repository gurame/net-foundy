using Dumpify;

namespace NetFoundy.DesignPatterns.Prototype.Implementation;

class PrototypeClient
{
    public static void Run()
    {
        var circle = new Circle(10, Color.White);
        var clonedCircle = circle.Clone();
        clonedCircle.Name = "Cloned Circle";
        circle.Dump();
    }
}