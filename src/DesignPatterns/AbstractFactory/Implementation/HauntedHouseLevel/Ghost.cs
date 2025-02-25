using NetFoundy.DesignPatterns.AbstractFactory.Implementation.Common;

namespace NetFoundy.DesignPatterns.AbstractFactory.Implementation.HauntedHouseLevel;

internal class Ghost : IEnemy
{
    public void Attack()
    {
        Console.WriteLine("Ghost attacked");
    }
}