using NetFoundy.DesignPatterns.FactoryMethod.Implementation.Enemies;

namespace NetFoundy.DesignPatterns.FactoryMethod.Implementation.Levels;

class HountedHouseLevel : Level
{
    public override IEnemy CreateEnemy()
    {
        return new Ghost();
    }
}