using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinbinCollections
{
    public static class CollectionExtension
    {
        public static bool IsNotContains<T>(this ICollection<T> collection, T arg)
        {
            return !collection.Contains(arg);
        }
        public static bool IsCollectionIncludeIn<T>(this IList<T> first, IList<T> seconde)
        {
            return first.All(seconde.Contains);
        }
        public static bool IsCollectionExcludeIn<T>(this IList<T> first, IList<T> seconde)
        {
            return first.All(seconde.IsNotContains);
        }
        public static bool IsCollectionEqualTo<T>(this IList<T> first, IList<T> second)
        {
            if (first.Count == second.Count)
            {
                return first.IsCollectionIncludeIn(second);
            }
            return false;
        }


    }
}
