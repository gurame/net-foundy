using NetFoundy.DesignPatterns.AbstractFactory.Implementation.Common;

namespace NetFoundy.DesignPatterns.AbstractFactory.Implementation.HauntedHouseLevel;

class HauntedHouseElementFactory : LevelElementFactory
{
    public override IEnemy CreateEnemy()
    {
        return new Ghost();
    }

    public override IPowerUp CreatePowerUp()
    {
        return new Orb();
    }

    public override IWeapon CreateWeapon()
    {
        return new Staff();
    }
}