using System;
using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class EnumerableExtensions
    {
        public static int IndexOf<T>(this IEnumerable<T> source, T item) where T : IEquatable<T>
        {
            ThrowIf.Argument.IsNull(source, "source");

            var comparer = EqualityComparer<T>.Default;
            var index = 0;
            foreach (var value in source)
            {
                if (comparer.Equals(value, item)) return index;
                index++;
            }

            return -1;
        }
    }
}