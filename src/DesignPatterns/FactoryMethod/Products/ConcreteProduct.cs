namespace NetFoundy.DesignPatterns.FactoryMethod.Products;
class ConcreteProduct : IProduct
{
    public void Operation()
    {
        // Do something
        Console.WriteLine("Calling ConcreteProduct.Operation()");
    }
}
