using System;
using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class EnumerableExtensions
    {
        public static int FindIndex<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            ThrowIf.Argument.IsNull(source, "source");
            ThrowIf.Argument.IsNull(predicate, "predicate");

            var index = 0;
            foreach (var value in source)
            {
                if (predicate(value)) return index;
                index++;
            }

            return -1;
        }
    }
}