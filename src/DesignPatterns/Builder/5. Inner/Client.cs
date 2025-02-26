namespace NetFoundy.DesignPatterns.Builder.Inner;

class InnerBuilderClient
{
    public static void Run()
    {
        Pizza pizza = new Pizza.Builder()
            .SetDough(dough => dough
                .SetThickness("Thin")
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