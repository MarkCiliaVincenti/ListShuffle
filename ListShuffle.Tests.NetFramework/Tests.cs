using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ListShuffle.Tests.NetFramework
{
    public class Tests
    {
        [Fact]
        public void TestOneCryptoStrongNetFramework()
        {
            var list = new List<int>();
            for (int j = 1; j <= 10000; j++)
            {
                list.Add(j);
            }

            list.CryptoStrongShuffle();

            if (list.First() == 1)
            {
                list.Shuffle();
            }

            Assert.False(list.First() == 1);
        }

        [Fact]
        public void TestConcurrencyCryptoStrongNetFramework()
        {
            int totalFives = 0;

            var result = Parallel.For(1, 100001, (i, state) =>
            {
                var list = new List<int>();
                for (int j = 1; j <= 10; j++)
                {
                    list.Add(j);
                }

                list.CryptoStrongShuffle();

                if (list.First() == 5)
                {
                    Interlocked.Increment(ref totalFives);
                }
            });

            Assert.InRange(totalFives, 5000, 20000);
        }
    }
}
