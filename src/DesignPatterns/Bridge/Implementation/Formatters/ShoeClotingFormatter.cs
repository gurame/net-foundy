using NetFoundy.DesignPatterns.Bridge.Implementation.Items;

namespace NetFoundy.DesignPatterns.Bridge.Implementation.Formatters;

class ShoeClotingFormatter(Shoe shoe) : IClothingFormatter
{
    public Uri FormatImageUrl()
    {
        return new Uri($"images/shoe_{shoe.Brand.ToLower()}-{shoe.Color.ToLower()}.jpg", UriKind.Relative);
    }

    public string FormatTitle()
    {
        return $"{shoe.Brand} {shoe.Color} Shoe";
    }

    public string FormatDescription()
    {
        return $"A {shoe.Color.ToLower()} {shoe.Brand} shoe made of {shoe.Material.ToLower()}";
    }
}