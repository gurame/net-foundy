namespace NetFoundy.DesignPatterns.Composite.Implementation;

abstract class LearningResource
{
    public abstract string GetName();
    public abstract decimal GetPrice();
    public abstract TimeSpan GetDuration();
    public virtual void Add(LearningResource component) { }
    public virtual void Remove(LearningResource component) { }
    public virtual LearningResource? GetLearningResource(string name) => null;
}