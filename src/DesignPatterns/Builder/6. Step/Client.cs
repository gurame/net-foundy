namespace NetFoundy.DesignPatterns.Builder.Step;

class StepBuilderClient
{
    public static void Run()
    {
        Pizza pizza = Pizza.Builder.Init()
            .SetDough(dough => dough
                .SetThickness("Thin Step")
                .SetFlavor("Garlic")
            )
            .SetSauce("Tomato")
            .SetCheese("Mozzarella")
            .AddTopping("Olives")
            .AddTopping("Mushrooms")
            .Build();

        Console.WriteLine(pizza);
    }
}