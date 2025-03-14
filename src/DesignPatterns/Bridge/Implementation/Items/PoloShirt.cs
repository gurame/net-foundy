namespace NetFoundy.DesignPatterns.Bridge.Implementation.Items;

public record PoloShirt(
    string Size,
    string Color,
    string Material,
    bool HasPocket = false,
    string Brand = "Generic"
);