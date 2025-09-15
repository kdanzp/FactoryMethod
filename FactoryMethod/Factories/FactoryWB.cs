using FactoryMethod.Models;

namespace FactoryMethod.Factories
{
    public class FactoryWB : MainFactory
    {
        public override IParser Create()
        {
            return new ParserWB();
        }
    }
}
