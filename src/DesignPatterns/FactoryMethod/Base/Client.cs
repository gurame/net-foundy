using NetFoundy.DesignPatterns.FactoryMethod.Base.Creators;
using NetFoundy.DesignPatterns.FactoryMethod.Base.Products;

namespace NetFoundy.DesignPatterns.FactoryMethod.Base;

class FactoryMethodClient
{
    public static void Run()
    {
        Creator creator = new ConcreteCreator();
        Product product = creator.CreateProduct();
        product.Operation();
    }
}