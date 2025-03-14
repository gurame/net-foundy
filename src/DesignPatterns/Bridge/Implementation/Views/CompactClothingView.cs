using NetFoundy.DesignPatterns.Bridge.Implementation.Formatters;

namespace NetFoundy.DesignPatterns.Bridge.Implementation.Views;

class CompactClothingView(IClothingFormatter clothingFormatter) : ClothingView(clothingFormatter)
{
    public override void Display()
    {
        Console.WriteLine("Compact view:");
        Console.WriteLine($"Title: {ClothingFormatter.FormatTitle()}");
        Console.WriteLine($"Description: {ClothingFormatter.FormatDescription()}");
    }
}