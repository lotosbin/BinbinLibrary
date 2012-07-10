using System.Collections.Generic;
using System.Text;

namespace RenrenRESTful
{
    /// <summary>
    /// 集合辅助类。
    /// </summary>
    public static class CollectionUtil
    {
        /// <summary>
        /// 将字符串字典里的数据转换成URL查询字符串格式。
        /// </summary>
        /// <param name="dict">字符串字典。</param>
        /// <returns></returns>
        public static string ToQueryString(IDictionary<string, string> dict)
        {
            if (dict.Count == 0) 
                return string.Empty;

            var buffer = new StringBuilder();
            var count = 0;
            var end = false;

            foreach (var key in dict.Keys)
            {
                if (count == dict.Count - 1) end = true;

                if (end)
                    buffer.AppendFormat("{0}={1}", key, dict[key]);
                else
                    buffer.AppendFormat("{0}={1}&", key, dict[key]);

                count++;
            }

            return buffer.ToString();
        }

        /// <summary>
        /// 将列表转换为逗号分隔的字符串。
        /// </summary>
        /// <param name="collection">列表。</param>
        /// <typeparam name="T">元素类型。</typeparam>
        /// <returns></returns>
        public static string ToCommaString<T>(IList<T> collection)
        {
            if (collection.Count == 0)
                return string.Empty;

            var buffer = new StringBuilder();

            for (int i = 0; i < collection.Count; i++)
            {
                if (i == collection.Count - 1)
                    buffer.Append(collection[i]);
                else
                    buffer.AppendFormat("{0},", collection[i]);
            }

            return buffer.ToString();
        }
    }
}