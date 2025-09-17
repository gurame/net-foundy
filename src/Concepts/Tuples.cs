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
        (byte FirstNumber, string Name, float SecondNumber) tupleB = (FirstNumber: 123, Name: "Hello", SecondNumber: 456);
        Console.WriteLine($"tupleA == tupleB: {tupleA == tupleB}");

        // Where tuples are stored? 
        // ValueTuple is store in the stack
        // Tuple is store in the heap
        var smallTuple = (1, 2); // 8 bytes
        var largeTuple = (1, 2, 3, 4, 5, 6); // 24 bytes
        Console.WriteLine($"smallTuple: {smallTuple.GetType().FullName}");
        Console.WriteLine($"largeTuple: {largeTuple.GetType().FullName}");

        var persona = (Name: "John", Age: 30);
        Console.WriteLine($"Name: {persona.Name}, Age: {persona.Age}");
        Console.WriteLine($"Tuple type: {persona.GetType().FullName}");
    }
}