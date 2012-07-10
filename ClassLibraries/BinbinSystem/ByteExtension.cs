using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Binbin.System
{
    public static class ByteExtension
    {
        public static string ToHex(this byte b)
        {
            return b.ToString("X2");
        }

        public static string ToHex(this IEnumerable<byte> bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
        public static string ToBase64String(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
        public static int ToInt(this byte[] value, int startIndex)
        {
            return BitConverter.ToInt32(value, startIndex);
        }
        public static long ToInt64(this byte[] value, int startIndex)
        {
            return BitConverter.ToInt64(value, startIndex);
        }

        public static string Decode(this byte[] data, Encoding encoding)
        {
            return encoding.GetString(data);
        }
        /// <summary>
        /// 使用指定算法Hash
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hashName"></param>
        /// <returns></returns>
        public static byte[] Hash(this byte[] data, string hashName)
        {
            HashAlgorithm algorithm;
            if (string.IsNullOrEmpty(hashName)) algorithm = HashAlgorithm.Create();
            else algorithm = HashAlgorithm.Create(hashName);
            return algorithm.ComputeHash(data);
        }
        /// <summary>
        /// 使用默认算法Hash
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Hash(this byte[] data)
        {
            return Hash(data, null);
        }
        //
        /// <summary>
        /// index从0开始获取取第index是否为1
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool GetBit(this byte b, int index)
        {
            return (b & (1 << index)) > 0;
        }
        /// <summary>
        /// 将第index位设为1
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte SetBit(this byte b, int index)
        {
            b |= (byte)(1 << index);
            return b;
        }
        /// <summary>
        /// 将第index位设为0
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte ClearBit(this byte b, int index)
        {
            b &= (byte)((1 << 8) - 1 - (1 << index));
            return b;
        }
        /// <summary>
        /// 将第index位取反
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte ReverseBit(this byte b, int index)
        {
            b ^= (byte)(1 << index);
            return b;
        }
        /// <summary>
        /// 保存为文件 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>
        public static void Save(this byte[] data, string path)
        {
            File.WriteAllBytes(path, data);
        }
        /// <summary>
        /// 转换为内存流
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this byte[] data)
        {
            return new MemoryStream(data);
        }
    }
}