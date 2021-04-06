using System.Collections.Generic;
using System.Linq;

namespace ExtraLinq
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<(TSource, int)> WithIndex<TSource>(this IEnumerable<TSource> source)
        {
            return source.Select((x, i) => (x, i));
        }
    }
}
