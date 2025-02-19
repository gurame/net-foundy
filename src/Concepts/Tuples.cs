namespace NetFoundy.Concepts;

class Tuples
{
    public static void Run()
    {
        var tuple = (1, "Hello", 3.14);
        Console.WriteLine(tuple.Item1);
        Console.WriteLine(tuple.Item2);
        Console.WriteLine(tuple.Item3);

        var tuple2 = (Id: 1, Name: "Hello", PI: 3.14);
        Console.WriteLine(tuple2.Id);
        Console.WriteLine(tuple2.Name);
        Console.WriteLine(tuple2.PI);

        var (id, name, pi) = tuple2;
        Console.WriteLine(id);
        Console.WriteLine(name);
        Console.WriteLine(pi);

        (int, string, int) tupleA = (123, "Hello", 456);
        (byte, string, float) tupleB = (FirstNumber: 123, Name: "Hello", SecondNumber: 456);
        Console.WriteLine($"tupleA == tupleB: {tupleA == tupleB}");

    }
}