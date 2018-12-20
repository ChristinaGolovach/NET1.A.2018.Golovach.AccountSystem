using System.Collections.Generic;

namespace BLL.Models.Factories
{    
    public static class FactoryCollection
    {
        private static IEnumerable<AccountFactory> factories;

        public static IEnumerable<AccountFactory> Factories { get => factories; }

        static FactoryCollection()
        {
            factories = new List<AccountFactory>() { new BaseAccountFactory(), new SilverAccountFactory(), new GoldenAccountFactory(), new PlatinumAccountFactory() };
        }
    }
}
