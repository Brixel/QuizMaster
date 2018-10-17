using System;
using System.Collections.Generic;

namespace HelloSignalR.Extensions
{
    public static class ListExtensions
    {
        public static int FindIndex<T>(this IList<T> list, Predicate<T> predicate)
        {
            for (var i = 0; i < list.Count; i++)
                if (predicate(list[i]))
                    return i;

            return -1;
        }

        public static bool RemoveOne<T>(this IList<T> list, Predicate<T> predicate)
        {
            for (var i = 0; i < list.Count; i++)
                if (predicate(list[i]))
                {
                    list.RemoveAt(i);
                    return true;
                }

            return false;
        }
    }
}