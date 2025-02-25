namespace NetFoundy.DesignPatterns.AbstractFactory.Implementation.Common;
abstract class LevelElementFactory
{
    public abstract IEnemy CreateEnemy();
    public abstract IPowerUp CreatePowerUp();
    public abstract IWeapon CreateWeapon();
}