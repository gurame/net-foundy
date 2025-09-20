namespace NetFoundy.Concepts;

class Records
{
    public record Person(string FirstName, string LastName);

    public record Animal
    {
        public string Name { get; set; }
    }
    public static void Run()
    {
        var person = new Person("John", "Doe");
        Console.WriteLine(person);
        var person2 = person with { FirstName = "Jane" };
        Console.WriteLine(person2);
        Console.WriteLine(person == person2);
        var person3 = new Person("Jane", "Doe");
        Console.WriteLine(person2 == person3);
        var (firstName, lastName) = person3;
        Console.WriteLine(firstName);
        Console.WriteLine(lastName);
        
        var animal = new Animal { Name = "Fido" };
        animal.Name = "Rex";
        
    }
}
