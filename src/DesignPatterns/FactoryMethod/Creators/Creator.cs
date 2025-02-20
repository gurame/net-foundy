using NetFoundy.DesignPatterns.FactoryMethod.Products;

namespace NetFoundy.DesignPatterns.FactoryMethod.Creators; 
abstract class Creator
{
    public abstract IProduct CreateProduct();
}