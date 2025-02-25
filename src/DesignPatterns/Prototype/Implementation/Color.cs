namespace NetFoundy.DesignPatterns.Prototype.Implementation;
class Color(ushort red, ushort green, ushort blue) : IPrototype<Color>
{
    public ushort Red => red;
    public ushort Green => green;
    public ushort Blue => blue;
    public static readonly Color White = new(255, 255, 255);
    public Color Clone()
    {
        return new Color(red, green, blue);
    }
}
    