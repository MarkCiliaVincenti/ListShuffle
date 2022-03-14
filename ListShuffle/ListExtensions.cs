using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using ThreadSafeRandomizer;

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
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is null.</exception>
        public static void Shuffle<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.Instance.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }

        /// <summary>
        /// Cryptographically-strong thread-safe shuffle of all items in the list. Less performant than <see cref="Shuffle"/>.
        /// </summary>
        /// <typeparam name="T">The generic type of the list to extend.</typeparam>
        /// <param name="list">The list to extend.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is null.</exception>
        public static void CryptoStrongShuffle<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            int n = list.Count;
#if NETSTANDARD2_0
            using (var generator = RandomNumberGenerator.Create())
#endif
            while (n > 1)
            {
                n--;

#if NETSTANDARD2_1
                int k = RandomNumberGenerator.GetInt32(n + 1);
#else
                var data = new byte[sizeof(uint)];
                generator.GetBytes(data);
                var randUint = BitConverter.ToUInt32(data, 0);
                int k = (int)Math.Floor((((double)n + 1) * (randUint / (uint.MaxValue + 1.0))));
#endif
                (list[n], list[k]) = (list[k], list[n]);
            }
        }
    }
}
