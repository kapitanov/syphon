using System.Collections.Generic;

namespace Syphon
{
    internal static class Lists
    {
        public static T Previous<T>(this IList<T> list, int index)
        {
            if (index == 0)
                return default(T);
            return list[index - 1];
        }

        public static T Next<T>(this IList<T> list, int index)
        {
            if (index >= list.Count - 1)
                return default(T);
            return list[index + 1];
        }
    }
}