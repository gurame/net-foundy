namespace NetFoundy.DesignPatterns.Bridge.Implementation.Items;

public record Shoe(
    string Brand,
    double Size,
    string Color,
    bool IsAthletic,
    string Material = "Leather"
);
