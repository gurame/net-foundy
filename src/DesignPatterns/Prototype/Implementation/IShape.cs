namespace NetFoundy.DesignPatterns.Prototype.Implementation;

interface IShape : IPrototype<IShape>
{
    string Name { get; set; }
}