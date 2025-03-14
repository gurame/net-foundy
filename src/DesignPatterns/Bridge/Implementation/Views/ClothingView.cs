using NetFoundy.DesignPatterns.Bridge.Implementation.Formatters;

namespace NetFoundy.DesignPatterns.Bridge.Implementation.Views;

abstract class ClothingView(IClothingFormatter clothingFormatter)
{
    protected IClothingFormatter ClothingFormatter { get; init; } = clothingFormatter;
    public abstract void Display();
}