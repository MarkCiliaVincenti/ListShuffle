using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ListShuffle.Tests.Net80
{
    public class Tests
    {
        [Fact]
        public void TestOneList()
        {
            var list = new List<int>();
            for (int j = 1; j <= 10000; j++)
            {
                list.Add(j);
            }

            list.Shuffle();

            if (list.First() == 1)
            {
                list.Shuffle();
            }

            Assert.False(list.First() == 1);
        }

        [Fact]
        public void TestOneArray()
        {
            var array = new int[10000];
            for (int j = 0; j < 10000;)
            {
                array[j] = ++j;
            }

            array.Shuffle();

            if (array.First() == 1)
            {
                array.Shuffle();
            }

            Assert.False(array.First() == 1);
        }

        [Fact]
        public void TestOneSpan()
        {
            Span<int> span = stackalloc int[10000];
            for (int j = 0; j < 10000;)
            {
                span[j] = ++j;
            }

            span.Shuffle();

            if (span[0] == 1)
            {
                span.Shuffle();
            }

            Assert.False(span[0] == 1);
        }

        [Fact]
        public void TestConcurrencyList()
        {
            int totalFives = 0;

            Parallel.For(1, 100001, (_, _) =>
            {
                var list = new List<int>();
                for (int j = 1; j <= 10; j++)
                {
                    list.Add(j);
                }

                list.Shuffle();

                if (list.First() == 5)
                {
                    Interlocked.Increment(ref totalFives);
                }
            });

            Assert.InRange(totalFives, 5000, 20000);
        }

        [Fact]
        public void TestConcurrencyArray()
        {
            int totalFives = 0;

            Parallel.For(1, 100001, (_, _) =>
            {
                var array = new int[10];
                for (int j = 0; j < 10;)
                {
                    array[j] = ++j;
                }

                array.Shuffle();

                if (array.First() == 5)
                {
                    Interlocked.Increment(ref totalFives);
                }
            });

            Assert.InRange(totalFives, 5000, 20000);
        }

        [Fact]
        public void TestConcurrencySpan()
        {
            int totalFives = 0;

            Parallel.For(1, 100001, (_, _) =>
            {
                Span<int> span = stackalloc int[10];
                for (int j = 0; j < 10;)
                {
                    span[j] = ++j;
                }

                span.Shuffle();

                if (span[0] == 5)
                {
                    Interlocked.Increment(ref totalFives);
                }
            });

            Assert.InRange(totalFives, 5000, 20000);
        }

        [Fact]
        public void TestOneCryptoStrongList()
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
        public void TestOneCryptoStrongArray()
        {
            var array = new int[10000];
            for (int j = 0; j < 10000;)
            {
                array[j] = ++j;
            }

            array.CryptoStrongShuffle();

            if (array.First() == 1)
            {
                array.CryptoStrongShuffle();
            }

            Assert.False(array.First() == 1);
        }

        [Fact]
        public void TestOneCryptoStrongSpan()
        {
            Span<int> span = stackalloc int[10000];
            for (int j = 0; j < 10000;)
            {
                span[j] = ++j;
            }

            span.CryptoStrongShuffle();

            if (span[0] == 1)
            {
                span.CryptoStrongShuffle();
            }

            Assert.False(span[0] == 1);
        }

        [Fact]
        public void TestConcurrencyCryptoStrongList()
        {
            int totalFives = 0;

            Parallel.For(1, 100001, (_, _) =>
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

        [Fact]
        public void TestConcurrencyCryptoStrongArray()
        {
            int totalFives = 0;

            Parallel.For(1, 100001, (_, _) =>
            {
                var array = new int[10];
                for (int j = 0; j < 10;)
                {
                    array[j] = ++j;
                }

                array.CryptoStrongShuffle();

                if (array.First() == 5)
                {
                    Interlocked.Increment(ref totalFives);
                }
            });

            Assert.InRange(totalFives, 5000, 20000);
        }

        [Fact]
        public void TestConcurrencyCryptoStrongSpan()
        {
            int totalFives = 0;

            Parallel.For(1, 100001, (_, _) =>
            {
                Span<int> span = stackalloc int[10];
                for (int j = 0; j < 10;)
                {
                    span[j] = ++j;
                }

                span.CryptoStrongShuffle();

                if (span[0] == 5)
                {
                    Interlocked.Increment(ref totalFives);
                }
            });

            Assert.InRange(totalFives, 5000, 20000);
        }
    }
}