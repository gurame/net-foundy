namespace NetFoundy.DesignPatterns.Builder.Classic;

class ClassicBuilderClient
{
    public static void Run()
    {
        IBuilder builder = new ComplexProductBuilder();
        ProductDirector director = new(builder);
        director.ConstructProduct();
        Product product = builder.Build();
        Console.WriteLine(product);
    }
}