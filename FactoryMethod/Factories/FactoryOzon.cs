using FactoryMethod.Models;

namespace FactoryMethod.Factories
{
    public class FactoryOzon : MainFactory
    {
        public override IParser Create()
        {
            return new ParserOzon();
        }
    }
}
