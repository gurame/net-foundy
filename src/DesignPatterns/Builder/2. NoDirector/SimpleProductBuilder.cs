namespace NetFoundy.DesignPatterns.Builder.NoDirector;

class SimpleProductBuilder : IBuilder
{
    private string _description = string.Empty;
    private string _name = string.Empty;

    public Product Build()
    {
        return new Product(_name, _description);
    }

    public void SetDescription()
    {
        _description = "Simple Product Description";
    }

    public void SetName()
    {
        _name = "Simple Product Name";
    }
}