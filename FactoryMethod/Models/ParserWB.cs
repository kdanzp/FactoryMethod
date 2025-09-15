namespace FactoryMethod.Models
{
    public class ParserWB : IParser
    {
        public string Name => "Wildberries";
        public string BaseUrl => "https://www.wildberries.ru/";
        public string TitelXpath => "//span[@class='product-card__name']";
        public string PriceXpath => "//ins[contains(@class, 'price__lower-price')]";
       
    }
}
