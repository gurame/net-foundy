namespace NetFoundy.DesignPatterns.Decorator.Implementation;
abstract class TeslaDecorator(ITeslaModel3 car) : ITeslaModel3
{
    protected readonly ITeslaModel3 _car = car;

    public virtual string GetDescription()
    {
        return _car.GetDescription();
    }

    public virtual decimal GetPrice()
    {
        return _car.GetPrice();
    }

    public virtual int GetRange()
    {
        return _car.GetRange();
    }
}