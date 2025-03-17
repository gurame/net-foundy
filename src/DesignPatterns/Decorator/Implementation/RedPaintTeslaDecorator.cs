namespace NetFoundy.DesignPatterns.Decorator.Implementation;
class RedPaintTeslaDecorator(ITeslaModel3 component) : TeslaDecorator(component)
{
    public override string GetDescription()
    {
        return $"{base.GetDescription()}, Red Paint";
    }
    public override decimal GetPrice()
    {
        return base.GetPrice() + 2000;
    }
    public override int GetRange()
    {
        return base.GetRange() + 10;
    }
}