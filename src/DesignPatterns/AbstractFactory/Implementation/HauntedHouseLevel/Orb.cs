using NetFoundy.DesignPatterns.AbstractFactory.Implementation.Common;

namespace NetFoundy.DesignPatterns.AbstractFactory.Implementation.HauntedHouseLevel;

internal class Orb : IPowerUp
{
    public void Use()
    {
        Console.WriteLine("Orb used");
    }
}
