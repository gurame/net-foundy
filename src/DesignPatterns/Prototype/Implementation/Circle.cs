namespace NetFoundy.DesignPatterns.Prototype.Implementation;

class Circle(int radius, Color color) : IShape
{
    public int Radius { get; set; } = radius;
    public Color Color { get; } = color;
    public string Name { get; set; } = "Circle";
    public  IShape Clone()
    {
        return new Circle(Radius, Color.Clone());
    }
}


