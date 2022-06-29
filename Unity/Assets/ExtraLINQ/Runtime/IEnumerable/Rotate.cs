using System.Collections.Generic;
using System.Linq;

namespace ExtraLinq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Rotate
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The sequence to repeat.</param>
        /// <param name="count">The number of times to repeat the sequence.</param>
        /// <returns>A rotated version of the original sequence.</returns>
        public static IEnumerable<TSource> Rotate<TSource>(this IEnumerable<TSource> source, int count)
        {
            ThrowIf.Argument.IsNull(source, "source");
            ThrowIf.Argument.IsNegative(count, "count");

            var sourceArray = source.ToArray();
            return sourceArray.Skip(count).Concat(sourceArray.Take(count));
        }
    }
}
