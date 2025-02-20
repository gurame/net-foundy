using NetFoundy.DesignPatterns.FactoryMethod.Products;

namespace NetFoundy.DesignPatterns.FactoryMethod.Creators;

class ConcreteCreator : Creator
{
    public override IProduct CreateProduct()
    {
        return new ConcreteProduct();
    }
}