using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Binbin.Attribute
{
    public static class AttributeExtension
    {
        public static TAttribute Get<TAttribute>(this MemberInfo memberInfo)
            where TAttribute : System.Attribute
        {
            return System.Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute)) as TAttribute;
        }
        //public static TAttribute Get<TAttribute>(this Type memberInfo)
        //    where TAttribute : Attribute
        //{
        //    return Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute)) as TAttribute;
        //}
        public static TAttribute Get<TAttribute>(this Assembly memberInfo)
            where TAttribute : System.Attribute
        {
            return System.Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute)) as TAttribute;
        }
        public static TAttribute Get<TAttribute>(this Module memberInfo)
            where TAttribute : System.Attribute
        {
            return System.Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute)) as TAttribute;
        }
        public static TAttribute Get<TAttribute>(this ParameterInfo memberInfo)
            where TAttribute : System.Attribute
        {
            return System.Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute)) as TAttribute;
        }
    }
}
