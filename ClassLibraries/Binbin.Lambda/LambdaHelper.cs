using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Binbin.Lambda
{
    /// <summary>
    /// Lambda表达式辅助类
    /// </summary>
    public static class LambdaHelper
    {
        /// <summary>
        /// 取得指定lambda表达是的属性名称.
        /// 例如:user=>user.Name
        /// 返回:"Name"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        public static string GetPropertyName<T>(Expression<Func<T, object>> property)
        {
            LambdaExpression lambda = property;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)(lambda.Body);
                memberExpression = (MemberExpression)(unaryExpression.Operand);
            }
            else
            {
                memberExpression = (MemberExpression)(lambda.Body);
            }

            return memberExpression.Member.Name;
        }
    }
}
