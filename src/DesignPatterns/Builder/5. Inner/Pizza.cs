namespace NetFoundy.DesignPatterns.Builder.Inner;

record Pizza(Dough Dough, string Sauce, string Cheese, List<string> Topping)
{
    public class Builder
    {
        private Dough _dough = default!;
        private string _sauce = string.Empty;
        private string _cheese = string.Empty;
        private readonly List<string> _topping = [];
        public Builder SetDough(Action<Dough.Builder> action)
        {
            var builder = new Dough.Builder();
            action(builder);
            _dough = builder.Build();
            return this;
        }

        public Builder SetSauce(string sauce)
        {
            _sauce = sauce;
            return this;
        }

        public Builder SetCheese(string cheese)
        {
            _cheese = cheese;
            return this;
        }

        public Builder AddTopping(string topping)
        {
            _topping.Add(topping);
            return this;
        }

        public Pizza Build()
        {
            return new Pizza(_dough, _sauce, _cheese, _topping);
        }
    }
}