using NetFoundy.DesignPatterns.AbstractFactory.Implementation.CaveLevel;
using NetFoundy.DesignPatterns.AbstractFactory.Implementation.Common;

namespace NetFoundy.DesignPatterns.AbstractFactory.Implementation;

class AbstractFactoryClient
{
    static void SetupEnvironment(LevelElementFactory levelElementFactory)
    {
        IEnemy enemy = levelElementFactory.CreateEnemy();
        enemy.Attack();
        IPowerUp powerUp = levelElementFactory.CreatePowerUp();
        powerUp.Use();
        IWeapon weapon = levelElementFactory.CreateWeapon();
        weapon.Obtain();
    }

    public static void Run()
    {
        SetupEnvironment(new CaveLevelElementFactory());
    }
}