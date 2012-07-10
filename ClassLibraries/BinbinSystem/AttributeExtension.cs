using System;
using System.Reflection;

namespace Binbin.System
{
    /// <summary>
    /// attribute ∑∫–Õ¿©’π
    /// </summary>
    public static class AttributeExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static TAttribute Get<TAttribute>(this MemberInfo memberInfo) where TAttribute : Attribute
        {
            return Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute)) as TAttribute;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static TAttribute Get<TAttribute>(this Assembly memberInfo) where TAttribute : Attribute
        {
            return Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute)) as TAttribute;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static TAttribute Get<TAttribute>(this Module memberInfo) where TAttribute : Attribute
        {
            return Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute)) as TAttribute;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static TAttribute Get<TAttribute>(this ParameterInfo memberInfo) where TAttribute : Attribute
        {
            return Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute)) as TAttribute;
        }
    }
}