using System.Collections.Generic;
using System.Linq;

namespace ExtraLinq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// rotate
        /// </summary>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RotateRight<TSource>(this IEnumerable<TSource> source, int count)
        {
            ThrowIf.Argument.IsNull(source, "source");

            if (count == 0) return source;
            if (count < 0) return RotateLeft(source, -count);

            var sourceArray = source as IReadOnlyList<TSource> ?? source.ToArray();
            var c = sourceArray.Count - (count % sourceArray.Count);
            return sourceArray.Skip(c).Concat(sourceArray.Take(c));
        }
    }
}