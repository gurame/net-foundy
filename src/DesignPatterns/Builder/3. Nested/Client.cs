namespace NetFoundy.DesignPatterns.Builder.Nested;

class NestedBuilderClient
{
    public static void Run()
    {
        Product.Builder builder = new();
        builder.BuildName("Product 1");
        builder.BuildDescription("Description 1");

        Product product = builder.Build();
        Console.WriteLine(product);
    }
}