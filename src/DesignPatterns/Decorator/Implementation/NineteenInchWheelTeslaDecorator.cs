namespace NetFoundy.DesignPatterns.Decorator.Implementation;
class NineteenInchWheelTeslaDecorator(ITeslaModel3 component) : TeslaDecorator(component)
{
    public override string GetDescription()
    {
        return $"{base.GetDescription()}, 19-inch Wheels";
    }
    public override decimal GetPrice()
    {
        return base.GetPrice() + 1500;
    }
    public override int GetRange()
    {
        return base.GetRange() + 30;
    }
}