namespace NetFoundy.DesignPatterns.FactoryMethod.Implementation.Enemies;
class Goblin : IEnemy
{
    public void Attack()
    {
        Console.WriteLine("Goblin attacks!");
    }
}
