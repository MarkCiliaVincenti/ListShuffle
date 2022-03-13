using System;
using System.Threading;

namespace ListShuffle
{
    internal class ThreadSafeRandom
    {
        private static readonly Random _global = new Random();
        private static readonly ThreadLocal<Random> _local = new ThreadLocal<Random>(() =>
        {
            int seed;
            lock (_global)
            {
                seed = _global.Next();
            }
            return new Random(seed);
        });

        public static int Next()
        {
            return _local.Value.Next();
        }
    }
}
