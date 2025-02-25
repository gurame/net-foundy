using NetFoundy.DesignPatterns.AbstractFactory.Implementation.Common;

namespace NetFoundy.DesignPatterns.AbstractFactory.Implementation.CaveLevel;

class CaveLevelElementFactory : LevelElementFactory
{
    public override IEnemy CreateEnemy()
    {
        return new Goblin();
    }

    public override IPowerUp CreatePowerUp()
    {
        return new Crystal();
    }

    public override IWeapon CreateWeapon()
    {
        return new Axe();
    }
}
