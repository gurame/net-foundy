namespace NetFoundy.DesignPatterns.Builder.NoDirector;
interface IBuilder
{
    void SetName();
    void SetDescription();
    Product Build();
}