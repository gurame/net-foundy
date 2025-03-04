namespace NetFoundy.DesignPatterns.Adapter.Implementation;

public class LegacyRectangle(int left, int right, int top, int bottom)
{
    public int CalculateArea()
    {
        return (right - left) * (bottom - top);
    }

    public int CalculatePerimeter()
    {
        return 2 * (right - left) + 2 * (bottom - top);
    }

    public void Shift(int delta)
    {
        left -= delta;
        right -= delta;
    }
}