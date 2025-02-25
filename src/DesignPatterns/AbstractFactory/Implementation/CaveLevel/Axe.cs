using NetFoundy.DesignPatterns.AbstractFactory.Implementation.Common;

namespace NetFoundy.DesignPatterns.AbstractFactory.Implementation.CaveLevel;

internal class Axe : IWeapon
{
    public void Obtain()
    {
        Console.WriteLine("Axe obtained");
    }
}
