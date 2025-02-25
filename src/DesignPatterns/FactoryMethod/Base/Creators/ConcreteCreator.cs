using NetFoundy.DesignPatterns.FactoryMethod.Base.Products;

namespace NetFoundy.DesignPatterns.FactoryMethod.Base.Creators;

class ConcreteCreator : Creator
{
    public override Product CreateProduct()
    {
        return new ConcreteProduct();
    }
}