namespace NetFoundy.DesignPatterns.Builder.Inner;

record Dough(string Thickness, string Flavor)
{
    public class Builder
    {
        private string _thickness = string.Empty;
        private string _flavor = string.Empty;

        public Builder SetThickness(string thickness)
        {
            _thickness = thickness;
            return this;
        }

        public Builder SetFlavor(string flavor)
        {
            _flavor = flavor;
            return this;
        }

        public Dough Build()
        {
            return new Dough(_thickness, _flavor);
        }
    }
}