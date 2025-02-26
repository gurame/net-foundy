namespace NetFoundy.DesignPatterns.Builder.Classic;

class ProductDirector(IBuilder builder)
{
    private readonly IBuilder _builder = builder;
    public void ConstructProduct()
    {
        _builder.SetName();
        _builder.SetDescription();
    }
}