namespace NetFoundy.DesignPatterns.FactoryMethod.Implementation.Enemies;
class Ghost : IEnemy
{
    public void Attack()
    {
        Console.WriteLine("Ghost attacks!");
    }
}
