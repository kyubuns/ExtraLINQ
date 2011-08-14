﻿using System;
using System.Collections.Generic;
using System.Linq;
using ExtraLINQ.Internals;

namespace ExtraLINQ
{
    /// <summary>
    /// Provides handy extension methods for collections.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines whether the specified collection contains exactly the specified number of items.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/> to count.</param>
        /// <param name="expectedItemCount">The number of items the specified collection is expected to contain.</param>
        /// <returns>
        ///   <c>true</c> if <paramref name="source"/> contains exactly <paramref name="expectedItemCount"/> items; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public static bool CountsExactly<TSource>(this IEnumerable<TSource> source, int expectedItemCount)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (expectedItemCount < 0)
            {
                throw new ArgumentException("The expected item count must not be negative.", "expectedItemCount");
            }

            return source.Count() == expectedItemCount;
        }

        /// <summary>
        /// Determines whether the specified collection contains exactly the specified number of items satisfying the specified condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/> to count satisfying items.</param>
        /// <param name="expectedItemCount">The number of satisfying items the specified collection is expected to contain.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        ///   <c>true</c> if <paramref name="source"/> contains exactly <paramref name="expectedItemCount"/> items satisfying the condition; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="expectedItemCount"/> is negative.</exception>
        /// <exception cref="ArgumentNullException">
        ///   <para><paramref name="source"/> is null.</para>
        ///   <para>- or - </para>
        ///   <para><paramref name="predicate"/> is null.</para>
        /// </exception>
        public static bool CountsExactly<TSource>(this IEnumerable<TSource> source, int expectedItemCount, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (expectedItemCount < 0)
            {
                throw new ArgumentException("The expected item count must not be negative.", "expectedItemCount");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return source.Count(predicate) == expectedItemCount;
        }

        /// <summary>
        /// Determines whether the specified collection's item count is equal to or lower than <paramref name="expectedMaxItemCount"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/> whose items to count.</param>
        /// <param name="expectedMaxItemCount">The maximum number of items the specified collection is expected to contain.</param>
        /// <returns>
        ///   <c>true</c> if the item count of <paramref name="source"/> is equal to or lower than <paramref name="expectedMaxItemCount"/>; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="expectedMaxItemCount"/> is negative.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public static bool CountsMax<TSource>(this IEnumerable<TSource> source, int expectedMaxItemCount)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (expectedMaxItemCount < 0)
            {
                throw new ArgumentException("The expected item count must not be negative.", "expectedMaxItemCount");
            }

            return source.Count() <= expectedMaxItemCount;
        }

        /// <summary>
        /// Determines whether the specified collection contains exactly <paramref name="expectedMaxItemCount"/> or less items satisfying a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/> whose items to count.</param>
        /// <param name="expectedMaxItemCount">The maximum number of items satisfying the specified condition the specified collection is expected to contain.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        ///   <c>true</c> if the item count of satisfying items is equal to or less than <paramref name="expectedMaxItemCount"/>; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <para><paramref name="source"/> is null.</para>
        ///   <para>- or - </para>
        ///   <para><paramref name="predicate"/> is null.</para>
        /// </exception>
        public static bool CountsMax<TSource>(this IEnumerable<TSource> source, int expectedMaxItemCount, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return source.Count(predicate) <= expectedMaxItemCount;
        }

        /// <summary>
        /// Determines whether the specified collection's item count is equal to or greater than <paramref name="expectedMinItemCount"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/> whose items to count.</param>
        /// <param name="expectedMinItemCount">The minimum number of items the specified collection is expected to contain.</param>
        /// <returns>
        ///   <c>true</c> if the item count of <paramref name="source"/> is equal to or greater than <paramref name="expectedMinItemCount"/>; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        /// <remarks>
        /// No exception is thrown in case a negative <paramref name="expectedMinItemCount"/> is passed.
        /// </remarks>
        public static bool CountsMin<TSource>(this IEnumerable<TSource> source, int expectedMinItemCount)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return source.Count() >= expectedMinItemCount;
        }

        /// <summary>
        /// Determines whether the specified collection contains exactly <paramref name="expectedMinItemCount"/> or more items satisfying a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/> whose items to count.</param>
        /// <param name="expectedMinItemCount">The minimum number of items satisfying the specified condition the specified collection is expected to contain.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        ///   <c>true</c> if the item count of satisfying items is equal to or greater than <paramref name="expectedMinItemCount"/>; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <para><paramref name="source"/> is null.</para>
        ///   <para>- or - </para>
        ///   <para><paramref name="predicate"/> is null.</para>
        ///   </exception>
        /// <remarks>
        /// No exception is thrown in case a negative <paramref name="expectedMinItemCount"/> is passed.
        /// </remarks>
        public static bool CountsMin<TSource>(this IEnumerable<TSource> source, int expectedMinItemCount, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return source.Count(predicate) >= expectedMinItemCount;
        }

        /// <summary>
        /// Returns the item at a specified index in a specified collection using a specified indexing strategy.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/>containing the item.</param>
        /// <param name="index">The item's index.</param>
        /// <param name="indexingStrategy">The <see cref="IndexingStrategy"/> to use.</param>
        /// <returns>The item at the specified index.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> is empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index, IndexingStrategy indexingStrategy)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            // We copy source to sourceList to avoid multiple enumerations of source.
            IList<TSource> sourceList = source.ToList();

            if (sourceList.IsEmpty())
            {
                throw new ArgumentException("source must not be empty.", "source");
            }

            switch (indexingStrategy)
            {
                case IndexingStrategy.Cyclic:
                {
                    index = CollectionIndexCalculator.CalculateCyclicIndex(index, sourceList.Count);

                    break;
                }
                case IndexingStrategy.Clamp:
                {
                    index = CollectionIndexCalculator.CalculateClampIndex(index, sourceList.Count);

                    break;
                }
            }

            return sourceList.ElementAt(index);
        }

        /// <summary>
        /// Determines whether the specified collection is empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/> to check for emptiness.</param>
        /// <returns>
        ///   <c>true</c> if <paramref name="source"/> is empty; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public static bool IsEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return !source.Any();
        }

        /// <summary>
        /// Determines whether the specified collection is null or empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/> to check for null or emptiness.</param>
        /// <returns>
        ///   <c>true</c> if <paramref name="source"/> is null or empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                return true;
            }

            return !source.Any();
        }

        /// <summary>
        /// Determines whether none of the elements of a collection satisfy a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/> to check for matches.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        ///   <c>true</c> if no element satisfies the specified condition; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <para><paramref name="source"/> is null.</para>
        ///   <para>- or - </para>
        ///   <para><paramref name="predicate"/> is null.</para>
        /// </exception>
        public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return !source.Any(predicate);
        }

        /// <summary>
        /// Returns a random element from <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/> to return an element from.</param>
        /// <returns>
        /// A random element from <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public static TSource Random<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            CollectionItemPicker<TSource> itemPicker = new CollectionItemPicker<TSource>(source);
            TSource randomItem = itemPicker.PickRandomItem();

            return randomItem;
        }

        /// <summary>
        /// Returns all elements of <paramref name="source"/> except <paramref name="item"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/>containing the item.</param>
        /// <param name="item">The item to remove.</param>
        /// <returns>
        /// All elements of <paramref name="source"/> except <paramref name="item"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public static IEnumerable<TSource> Without<TSource>(this IEnumerable<TSource> source, TSource item)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return source.Where(element => !element.Equals(item));
        }

        /// <summary>
        /// Returns all elements of <paramref name="source"/> except <paramref name="item"/> using the specified equality comparer to compare values.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}"/> containing the item.</param>
        /// <param name="item">The item to remove.</param>
        /// <param name="equalityComparer">The equality comparer to use.</param>
        /// <returns>
        /// All elements of <paramref name="source"/> except <paramref name="item"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///   <para><paramref name="source"/> is null.</para>
        ///   <para>- or - </para>
        ///   <para><paramref name="equalityComparer"/> is null.</para>
        ///   </exception>
        public static IEnumerable<TSource> Without<TSource>(this IEnumerable<TSource> source, TSource item,
            IEqualityComparer<TSource> equalityComparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (equalityComparer == null)
            {
                throw new ArgumentNullException("equalityComparer");
            }

            return source.Where(element => !equalityComparer.Equals(element, item));
        }
    }
}
