using System.Linq;

namespace Binbin.Linq.Dynamic
{
    public static class DynamicQueryableExtension
    {
        public static bool IsExist(this IQueryable source)
        {
            return source.Count() > 0;
        }
        public static bool IsNotExist(this IQueryable source)
        {
            return !source.IsExist();
        }
    }
}