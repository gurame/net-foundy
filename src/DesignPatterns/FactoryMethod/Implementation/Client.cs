using NetFoundy.DesignPatterns.FactoryMethod.Implementation.Levels;

namespace NetFoundy.DesignPatterns.FactoryMethod.Implementation;

class FactoryMethodClient
{
    public static void Run()
    {
        Level level1 = LevelFactory.CreateLevel(levelNumber: 1);
        level1.EncounterEnemy();
        
        Level level2 = LevelFactory.CreateLevel(2);
        level2.EncounterEnemy();
    }
}