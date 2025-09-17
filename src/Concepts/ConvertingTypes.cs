
class ConvertingTypes
{
    public static void Run()
    {
        var type1 = new MyType { Value = 42 };
        // as vs is
        if (type1 is MyType)
        {
            Console.WriteLine("type1 is MyType");
        }
        var type2 = type1 as MyType;
        if (type2 != null)
        {
            Console.WriteLine("type1 as MyType succeeded");
        }

        // implicit vs explicit
        int a = 10;
        double b = a; // implicit
        Console.WriteLine(b);
        decimal c = 9.8m;
        int d = (int)c; // explicit
        Console.WriteLine(d);
    }
}

class MyType
{
    public int Value { get; set; }
}

class MyOtherType
{
    public int Value { get; set; }
}