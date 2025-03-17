namespace NetFoundy.DesignPatterns.Composite.Implementation;

class CompositeClient
{
    public static void Run() { 
        LearningResource root = new Bundle(name: "AI Deep Dive");
        
        LearningResource leaf1 = new Course(name: "AI Fundamentals", price: 100m, duration: TimeSpan.FromHours(2));
        root.Add(leaf1);

        LearningResource leaf2 = new Course(name: "AI Advanced", price: 200m, duration: TimeSpan.FromHours(4));
        root.Add(leaf2);

        Console.WriteLine($"Total price: {root.GetPrice()}");
        Console.WriteLine($"Total duration: {root.GetDuration()}");
    }
}