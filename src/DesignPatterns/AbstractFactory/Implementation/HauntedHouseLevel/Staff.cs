using NetFoundy.DesignPatterns.AbstractFactory.Implementation.Common;

namespace NetFoundy.DesignPatterns.AbstractFactory.Implementation.HauntedHouseLevel;

internal class Staff : IWeapon
{
    public void Obtain()
    {
        Console.WriteLine("Staff obtained");
    }
}
