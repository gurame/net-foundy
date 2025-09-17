using System.Security.Cryptography.X509Certificates;

class Operators
{
    public static void Run()
    {
        var v1 = new Vector(1, 2);
        var v2 = new Vector(3, 4);
        var v3 = v1 + v2;
        System.Console.WriteLine($"v3: ({v3.X}, {v3.Y})");
    }
}

struct Vector(int x, int y)
{
    public int X = x;
    public int Y = y;

    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.X + b.X, a.Y + b.Y);
    }
}