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
        public static IEnumerable<TSource> RotateLeft<TSource>(this IEnumerable<TSource> source, int count)
        {
            ThrowIf.Argument.IsNull(source, "source");

            if (count < 0) return RotateRight(source, -count);

            var sourceArray = source.ToArray();
            var c = count % sourceArray.Length;
            return sourceArray.Skip(c).Concat(sourceArray.Take(c));
        }
    }
}
