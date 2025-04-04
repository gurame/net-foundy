namespace NetFoundy.DesignPatterns.Builder.Classic;

class ComplexProductBuilder : IBuilder
{
    private string _description = string.Empty;
    private string _name = string.Empty;

    public Product Build()
    {
        return new Product(_name, _description);
    }

    public void SetDescription()
    {
        _description = "Complex Product Description";
    }

    public void SetName()
    {
        _name = "Complex Product Name";
    }
}
