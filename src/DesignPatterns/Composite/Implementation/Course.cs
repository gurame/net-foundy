
namespace NetFoundy.DesignPatterns.Composite.Implementation;

class Course(string name, decimal price, TimeSpan duration) : LearningResource
{
    public override string GetName()
    {
        return name;
    }
    public override decimal GetPrice()
    {
        return price;
    }
    public override TimeSpan GetDuration()
    {
        return duration;
    }
}