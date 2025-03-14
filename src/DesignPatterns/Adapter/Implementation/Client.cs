namespace NetFoundy.DesignPatterns.Adapter.Implementation;

class AdapterClient
{
    public static void CenterRectangle(IRectangle rectangle)
    {
        rectangle.Move(50);
    }
    public static void Run()
    {
        LegacyRectangle legacyRectangle = new(0, 0, 100, 100);
        IRectangle rectangle = new LegacyRectangleAdapter(legacyRectangle);
        CenterRectangle(rectangle);
    }
}