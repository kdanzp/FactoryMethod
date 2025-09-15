namespace FactoryMethod.Models
{
    public interface IParser
    {
        string Name { get; }
        string BaseUrl { get; }
        string TitelXpath { get; }
        string PriceXpath { get; }
    }
}
