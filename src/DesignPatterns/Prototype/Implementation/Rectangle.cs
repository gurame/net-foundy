namespace NetFoundy.DesignPatterns.Prototype.Implementation;

class Rectangle(int Width, int Height) : IShape
{
    public string Name { get; set; } = "Rectangle";
    public IShape Clone()
    {
        return new Rectangle(Width, Height);
    }
}