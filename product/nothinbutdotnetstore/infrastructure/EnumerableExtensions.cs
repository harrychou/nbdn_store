using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
    static public class EnumerableExtensions
    {
        static public void each<T>(this IEnumerable<T> items, Action<T> visitor)
        {
            foreach (var item in items) visitor(item);
        }
    }
}