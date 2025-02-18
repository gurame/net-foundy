namespace NetFoundy.Concepts;
class ReferenceTypes
{
    static void ChangeList(List<string> names)
    {
        names.Add("John");
        names.Add("Nick");
        names = new List<string>(); // This line creates points to a new address and does not affect the original list   
    }
    public static void Run()
    {
        var names = new List<string>() { "Alice", "Bob" };
        ChangeList(names);
        Console.WriteLine(string.Join(", ", names)); // Alice, Bob, John, Nick
    }
}