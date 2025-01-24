namespace NetFoundy.Concepts;
class ReferenceTypes
{
    static void ChangeList(List<string> names)
    {
        names = new List<string>(); // This line creates points to a new address and does not affect the original list
        names.Add("John");
        names.Add("Nick");
    }
    public static void Run()
    {
        var names = new List<string>() { "Alice", "Bob" };
        ChangeList(names);
        Console.WriteLine(string.Join(", ", names)); // Alice, Bob, John, Nick
    }
}