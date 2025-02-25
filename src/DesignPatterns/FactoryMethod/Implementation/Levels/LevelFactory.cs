namespace NetFoundy.DesignPatterns.FactoryMethod.Implementation.Levels;

class LevelFactory
{
    public static Level CreateLevel(int levelNumber)
    {
        return levelNumber switch
        {
            1 => new CaveLevel(),
            2 => new HountedHouseLevel(),
            _ => throw new ArgumentException("Invalid level number", nameof(levelNumber))
        };
    }
}