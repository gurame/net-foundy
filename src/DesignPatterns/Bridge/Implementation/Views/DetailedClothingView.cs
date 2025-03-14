using NetFoundy.DesignPatterns.Bridge.Implementation.Formatters;

namespace NetFoundy.DesignPatterns.Bridge.Implementation.Views;

class DetailedClothingView(IClothingFormatter clothingFormatter) : ClothingView(clothingFormatter)
{
    public override void Display()
    {
        Console.WriteLine("Detailed view:");
        Console.WriteLine($"Title: {ClothingFormatter.FormatTitle()}");
        Console.WriteLine($"Description: {ClothingFormatter.FormatDescription()}");
        Console.WriteLine($"Url: {ClothingFormatter.FormatImageUrl()}");
    }
}