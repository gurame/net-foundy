using NetFoundy.DesignPatterns.AbstractFactory.Base.Products;

namespace NetFoundy.DesignPatterns.AbstractFactory.Base.Factories;

class ConcreteFactory : AbstractFactory
{
    public override Product1 CreateProduct1()
    {
        return new ConcreteProduct1();
    }

    public override Product2 CreateProduct2()
    {
        return new ConcreteProduct2();
    }
}

