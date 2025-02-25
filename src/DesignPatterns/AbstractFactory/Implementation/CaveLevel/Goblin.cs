using NetFoundy.DesignPatterns.AbstractFactory.Implementation.Common;

namespace NetFoundy.DesignPatterns.AbstractFactory.Implementation.CaveLevel;

internal class Goblin : IEnemy
{
    public void Attack()
    {
        Console.WriteLine("Goblin attacked");
    }
}