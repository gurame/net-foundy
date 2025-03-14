namespace NetFoundy.DesignPatterns.Bridge.Implementation.Formatters;
interface IClothingFormatter
{
    Uri FormatImageUrl();
    string FormatTitle();
    string FormatDescription();
}