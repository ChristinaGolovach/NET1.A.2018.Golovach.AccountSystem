using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    internal static class FactoryCollection
    {
        private static IEnumerable<AccountFactory> factories;

        public static IEnumerable<AccountFactory> Factories { get => factories; }

        static FactoryCollection()
        {
            factories = new List<AccountFactory>() { new BaseAccountFactory(), new SilverAccountFactory(), new GoldenAccountFactory(), new PlatinumAccountFactory() };
        }
    }
}
