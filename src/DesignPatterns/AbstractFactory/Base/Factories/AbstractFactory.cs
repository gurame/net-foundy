using NetFoundy.DesignPatterns.AbstractFactory.Base.Products;

namespace NetFoundy.DesignPatterns.AbstractFactory.Base.Factories;

abstract class AbstractFactory
{
    public abstract Product1 CreateProduct1();
    public abstract Product2 CreateProduct2();
}