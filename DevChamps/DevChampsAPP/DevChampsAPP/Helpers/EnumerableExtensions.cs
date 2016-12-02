using System;
using System.Collections.Generic;

namespace DevChampsAPP
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var cur in enumerable)
            {
                action(cur);
            }
        }

        public static void ForEach<T>(this IList<T> list, Action<T> action)
        {
            foreach (var cur in list)
            {
                action(cur);
            }
        }
    }
}
