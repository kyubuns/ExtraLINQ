using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraLinq
{
    public static partial class EnumerableExtensions
    {
        public static bool TryGetLast<TSource>(this IEnumerable<TSource> source, out TSource result)
        {
            ThrowIf.Argument.IsNull(source, "source");

            result = default;
            foreach (var item in source.Reverse())
            {
                result = item;
                return true;
            }

            return false;
        }

        public static bool TryGetLast<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, out TSource result)
        {
            ThrowIf.Argument.IsNull(source, "source");
            ThrowIf.Argument.IsNull(predicate, "predicate");

            result = default;
            foreach (var item in source.Reverse())
            {
                if (predicate(item))
                {
                    result = item;
                    return true;
                }
            }

            return false;
        }
    }
}