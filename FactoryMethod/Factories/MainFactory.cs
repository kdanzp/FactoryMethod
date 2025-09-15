using FactoryMethod.Models;

namespace FactoryMethod.Factories
{
    public abstract class MainFactory
    {
        /// <summary>
        /// Создатель фабрики.
        /// </summary>
        /// <returns></returns>
        public abstract IParser Create();
    }
}
