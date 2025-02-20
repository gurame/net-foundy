
using NetFoundy.DesignPatterns.FactoryMethod.Creators;
using NetFoundy.DesignPatterns.FactoryMethod.Products;

namespace NetFoundy.DesignPatterns.FactoryMethod;

class FactoryMethodClient
{
    public static void Run()
    {
        Creator creator = new ConcreteCreator();
        IProduct product = creator.CreateProduct();
        product.Operation();
    }
}