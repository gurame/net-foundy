
namespace NetFoundy.DesignPatterns.Composite.Implementation;

class Bundle(string name) : LearningResource
{
    private readonly List<LearningResource> _children = [];
    public override void Add(LearningResource component)
    {
        _children.Add(component);
    }
    public override void Remove(LearningResource component)
    {
        _children.Remove(component);
    }
    public override LearningResource? GetLearningResource(string name)
    {
        return _children.FirstOrDefault(x => x.GetName() == name);
    }

    public override string GetName()
    {
        return name;
    }
    public override decimal GetPrice()
    {
        return _children.Sum(x => x.GetPrice()) * 0.8m;
    }
    public override TimeSpan GetDuration()
    {
        //return _children.Aggregate(TimeSpan.Zero, (acc, x) => acc + x.GetDuration());
        return new TimeSpan(_children.Sum(x => x.GetDuration().Ticks));
    }
}