using System;
using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class EnumerableExtensions
    {
        public static T MinBy<T, TComparable>(this IEnumerable<T> source, Func<T, TComparable> comparer) where TComparable : IComparable<TComparable>
        {
            ThrowIf.Argument.IsNull(source, "source");
            ThrowIf.Argument.IsNull(comparer, "comparer");

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext()) throw new InvalidOperationException();
                var value = enumerator.Current;
                var index = comparer(value);
                while (enumerator.MoveNext())
                {
                    var v = enumerator.Current;
                    var t = comparer(v);

                    if (index.CompareTo(t) < 0) continue;

                    value = v;
                    index = t;
                }

                return value;
            }
        }
    }
}
