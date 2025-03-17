namespace NetFoundy.DesignPatterns.Decorator.Implementation;
class BasicTeslaModel3 : ITeslaModel3
{
    public string GetDescription()
    {
        return "Basic Tesla Model 3";
    }

    public decimal GetPrice()
    {
        return 35000;
    }

    public int GetRange()
    {
        return 220;
    }
}