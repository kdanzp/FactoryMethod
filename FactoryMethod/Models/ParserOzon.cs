namespace FactoryMethod.Models
{
    public class ParserOzon : IParser
    {
        public string Name => "Ozon";
        public string BaseUrl => "https://www.ozon.ru/";
        public string TitelXpath => "//div[contains(@class, 'root')]//a//span";
        public string PriceXpath => "//div[contains(@class, 'root')]//span[contains(@class, 'Headline')]";
    }
}
