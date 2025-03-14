using NetFoundy.DesignPatterns.Bridge.Implementation.Formatters;
using NetFoundy.DesignPatterns.Bridge.Implementation.Items;
using NetFoundy.DesignPatterns.Bridge.Implementation.Views;

namespace NetFoundy.DesignPatterns.Bridge.Implementation;

class BridgeClient
{
    public static void Run()
    {
        Shoe shoe = new("Nike", 6, "White", true);
        IClothingFormatter shoeClothingFormatter = new ShoeClotingFormatter(shoe);
        ClothingView detailedView = new DetailedClothingView(shoeClothingFormatter);
        detailedView.Display();
        ClothingView compactView = new CompactClothingView(shoeClothingFormatter);
        compactView.Display();
    }
}