namespace NetFoundy.DesignPatterns.Builder.Step;

record Pizza(Dough Dough, string Sauce, string Cheese, List<string> Topping)
{
    public class Builder : IDoughStep, ISauceStep, ICheeseStep, IToppingStep
    {
        private Dough _dough = default!;
        private string _sauce = string.Empty;
        private string _cheese = string.Empty;
        private readonly List<string> _topping = [];
        private Builder() { }
        public static IDoughStep Init() => new Builder();
        public ISauceStep SetDough(Action<Dough.Builder> action)
        {
            var builder = new Dough.Builder();
            action(builder);
            _dough = builder.Build();
            return this;
        }

        public ICheeseStep SetSauce(string sauce)
        {
            _sauce = sauce;
            return this;
        }

        public IToppingStep SetCheese(string cheese)
        {
            _cheese = cheese;
            return this;
        }

        public IToppingStep AddTopping(string topping)
        {
            _topping.Add(topping);
            return this;
        }

        public Pizza Build()
        {
            return new Pizza(_dough, _sauce, _cheese, _topping);
        }
    }

    public interface IDoughStep
    {
        ISauceStep SetDough(Action<Dough.Builder> action);
    }
    public interface ISauceStep
    {
        ICheeseStep SetSauce(string sauce);
    }
    public interface ICheeseStep
    {
        IToppingStep SetCheese(string cheese);
    }
    public interface IToppingStep
    {
        IToppingStep AddTopping(string topping);
        Pizza Build();
    }
}