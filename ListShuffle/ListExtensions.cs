using System.Collections.Generic;
using System.Linq;

namespace ListShuffle
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            list = list.OrderBy(i => ThreadSafeRandom.Next()).ToList();
        }
    }
}
