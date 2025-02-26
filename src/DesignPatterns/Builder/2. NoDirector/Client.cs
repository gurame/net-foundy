namespace NetFoundy.DesignPatterns.Builder.NoDirector;

class NoDirectorBuilderClient
{
    public static void Run()
    {
        IBuilder builder = new ComplexProductBuilder();
        builder.SetName();
        builder.SetDescription();
        Product product = builder.Build();
        Console.WriteLine(product);
    }
}