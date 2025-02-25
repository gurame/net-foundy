using NetFoundy.DesignPatterns.FactoryMethod.Implementation.Enemies;
using NetFoundy.DesignPatterns.FactoryMethod.Implementation.Levels;

namespace NetFoundy.DesignPatterns.FactoryMethod.Implementation;

class FactoryMethodClient
{
    public static void Run()
    {
        Level level1 = new CaveLevel();
        level1.EncounterEnemy();
        
        Level level2 = new HountedHouseLevel();
        level2.EncounterEnemy();
    }
}