using NetFoundy.DesignPatterns.FactoryMethod.Base.Products;

namespace NetFoundy.DesignPatterns.FactoryMethod.Base.Creators; 
abstract class Creator
{
    public abstract Product CreateProduct();
}