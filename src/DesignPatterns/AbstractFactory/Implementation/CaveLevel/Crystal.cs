using NetFoundy.DesignPatterns.AbstractFactory.Implementation.Common;

namespace NetFoundy.DesignPatterns.AbstractFactory.Implementation.CaveLevel;

internal class Crystal : IPowerUp
{
    public void Use()
    {
        Console.WriteLine("Crystal used");
    }
}
