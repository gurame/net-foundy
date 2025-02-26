namespace NetFoundy.DesignPatterns.Builder.Fluent;

class FluentBuilderClient
{
    public static void Run()
    {
        Product product = new Product.Builder()
            .SetName("Product 1")
            .SetDescription("Description 1")
            .Build();

        Console.WriteLine(product);
    }
} 