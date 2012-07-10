using System.Collections.Generic;

namespace Binbin.System
{
    public static class DictionaryExtension
    {
        /// <summary>
        /// ���Խ�����ֵ��ӵ��ֵ��У���������ڣ�����ӣ����ڣ������Ҳ���׵���
        /// </summary>
        public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key) == false) dict.Add(key, value);
            return dict;
        }
        /// <summary>
        /// ������ֵ��ӻ��滻���ֵ��У���������ڣ�����ӣ����ڣ����滻
        /// </summary>
        public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict[key] = value;
            return dict;
        }
        /// <summary>
        /// ��ȡ��ָ���ļ��������ֵ�����û���򷵻������Ĭ��ֵ
        /// </summary>
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
        {
            return dict.ContainsKey(key) ? dict[key] : defaultValue;
        }
        /// <summary>
        /// ���ֵ���������Ӽ�ֵ��
        /// </summary>
        /// <param name="replaceExisted">����Ѵ��ڣ��Ƿ��滻</param>
        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> values, bool replaceExisted)
        {
            foreach (var item in values)
            {
                if (dict.ContainsKey(item.Key) == false || replaceExisted)
                    dict[item.Key] = item.Value;
            }
            return dict;
        }
    }
}