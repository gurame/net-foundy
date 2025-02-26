namespace NetFoundy.DesignPatterns.Builder.Classic;
interface IBuilder
{
    void SetName();
    void SetDescription();
    Product Build();
}