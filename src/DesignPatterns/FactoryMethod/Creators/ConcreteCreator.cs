using NetFoundy.DesignPatterns.FactoryMethod.Products;

namespace NetFoundy.DesignPatterns.FactoryMethod.Creators;

class ConcreteCreator : Creator
{
    public override Product CreateProduct()
    {
        return new ConcreteProduct();
    }
}