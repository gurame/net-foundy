namespace NetFoundy.DesignPatterns.Adapter.Implementation;

class LegacyRectanleAdapter(LegacyRectangle rectangle) : IRectangle
{
    public long GetArea()
    {
        return rectangle.CalculateArea();
    }

    public long GetPerimeter()
    {
        return rectangle.CalculatePerimeter();
    }

    public void Move(long x)
    {
        rectangle.Shift(Convert.ToInt32(x));
    }
}
