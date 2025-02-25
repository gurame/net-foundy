using NetFoundy.DesignPatterns.FactoryMethod.Implementation.Enemies;

namespace NetFoundy.DesignPatterns.FactoryMethod.Implementation.Levels;

class CaveLevel : Level
{
    public override IEnemy CreateEnemy()
    {
        return new Goblin();
    }
}
