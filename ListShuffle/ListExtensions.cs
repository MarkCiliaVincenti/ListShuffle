using System;
using System.Collections.Generic;
using System.Linq;

namespace ListShuffle
{
    /// <summary>
    /// ListShuffle extension class
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Thread-safe shuffle of all items in the list.
        /// </summary>
        /// <typeparam name="T">The generic type of the list to extend.</typeparam>
        /// <param name="list">The list to extend.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            list = list.OrderBy(i => ThreadSafeRandom.Next()).ToList();
        }
    }
}
