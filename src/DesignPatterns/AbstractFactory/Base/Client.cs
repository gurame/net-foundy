using NetFoundy.DesignPatterns.AbstractFactory.Base.Factories;
using NetFoundy.DesignPatterns.AbstractFactory.Base.Products;
using AF = NetFoundy.DesignPatterns.AbstractFactory.Base.Factories.AbstractFactory;

namespace NetFoundy.DesignPatterns.AbstractFactory.Base;

class AbstractFactoryClient
{
    static void Run()
    {
        AF abstractFactory = new ConcreteFactory();
        Product1 product1 = abstractFactory.CreateProduct1();
        Product2 product2 = abstractFactory.CreateProduct2();
    }
}