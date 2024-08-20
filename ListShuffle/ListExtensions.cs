using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Shuffle<T>(this IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            int n = list.Count;
            while (n > 1)
            {
                int k = ThreadSafeRandom.Instance.Next(n--);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }

        /// <summary>
        /// Thread-safe shuffle of all items in the array.
        /// </summary>
        /// <typeparam name="T">The generic type of the array to extend.</typeparam>
        /// <param name="array">The array to extend.</param>
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is null.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Shuffle<T>(this T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
#if NET8_0_OR_GREATER
            ThreadSafeRandom.Instance.Shuffle(array);
#else
            int n = array.Length;

            while (n > 1)
            {
                int k = ThreadSafeRandom.Instance.Next(n--);
                (array[n], array[k]) = (array[k], array[n]);
            }
#endif
        }

        /// <summary>
        /// Thread-safe shuffle of all items in the span.
        /// </summary>
        /// <typeparam name="T">The generic type of the span to extend.</typeparam>
        /// <param name="span">The span to extend.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Shuffle<T>(this Span<T> span)
        {
#if NET8_0_OR_GREATER
            ThreadSafeRandom.Instance.Shuffle(span);
#else
            int n = span.Length;

            while (n > 1)
            {
                int k = ThreadSafeRandom.Instance.Next(n--);
                (span[n], span[k]) = (span[k], span[n]);
            }
#endif
        }

        /// <summary>
        /// Cryptographically-strong thread-safe shuffle of all items in the list. Less performant than <see cref="Shuffle{T}(IList{T})"/>.
        /// </summary>
        /// <typeparam name="T">The generic type of the list to extend.</typeparam>
        /// <param name="list">The list to extend.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is null.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CryptoStrongShuffle<T>(this IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            int n = list.Count;
#if NETSTANDARD2_0
            using var generator = RandomNumberGenerator.Create();
#endif
            while (n > 1)
            {
#if NETSTANDARD2_1 || NET6_0_OR_GREATER
                int k = RandomNumberGenerator.GetInt32(n--);
#else
                var data = new byte[sizeof(uint)];
                generator.GetBytes(data);
                var randUint = BitConverter.ToUInt32(data, 0);
                int k = (int)Math.Floor(n-- * (randUint / (uint.MaxValue + 1.0)));
#endif
                (list[n], list[k]) = (list[k], list[n]);
            }
        }

        /// <summary>
        /// Cryptographically-strong thread-safe shuffle of all items in the array. Less performant than <see cref="Shuffle{T}(T[])"/>.
        /// </summary>
        /// <typeparam name="T">The generic type of the array to extend.</typeparam>
        /// <param name="array">The array to extend.</param>
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is null.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CryptoStrongShuffle<T>(this T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            int n = array.Length;
#if NETSTANDARD2_0
            using var generator = RandomNumberGenerator.Create();
#endif
            while (n > 1)
            {
#if NETSTANDARD2_1 || NET6_0_OR_GREATER
                int k = RandomNumberGenerator.GetInt32(n--);
#else
                var data = new byte[sizeof(uint)];
                generator.GetBytes(data);
                var randUint = BitConverter.ToUInt32(data, 0);
                int k = (int)Math.Floor(n-- * (randUint / (uint.MaxValue + 1.0)));
#endif
                (array[n], array[k]) = (array[k], array[n]);
            }
        }

        /// <summary>
        /// Cryptographically-strong thread-safe shuffle of all items in the span. Less performant than <see cref="Shuffle{T}(Span{T})"/>.
        /// </summary>
        /// <typeparam name="T">The generic type of the span to extend.</typeparam>
        /// <param name="span">The span to extend.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CryptoStrongShuffle<T>(this Span<T> span)
        {
            int n = span.Length;
#if NETSTANDARD2_0
            using var generator = RandomNumberGenerator.Create();
#endif
            while (n > 1)
            {
#if NETSTANDARD2_1 || NET6_0_OR_GREATER
                int k = RandomNumberGenerator.GetInt32(n--);
#else
                var data = new byte[sizeof(uint)];
                generator.GetBytes(data);
                var randUint = BitConverter.ToUInt32(data, 0);
                int k = (int)Math.Floor(n-- * (randUint / (uint.MaxValue + 1.0)));
#endif
                (span[n], span[k]) = (span[k], span[n]);
            }
        }
    }
}
