using NetFoundy.DesignPatterns.FactoryMethod.Implementation.Enemies;
    
namespace NetFoundy.DesignPatterns.FactoryMethod.Implementation.Levels;

abstract class Level
{
    public abstract IEnemy CreateEnemy();
    public void EncounterEnemy()
    {
        IEnemy enemy = CreateEnemy();
        enemy.Attack();
    }
}