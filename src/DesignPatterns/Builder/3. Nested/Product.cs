namespace NetFoundy.DesignPatterns.Builder.Nested;
record Product(string Name, string Description)
{
    public class Builder
    {
        private string _name = string.Empty;
        private string _description = string.Empty;

        public void BuildName(string name)
        {
            _name = name;
        }
        public void BuildDescription(string description)
        {
            _description = description;
        }
        public Product Build()
        {
            return new Product(_name, _description);
        }
    }
}