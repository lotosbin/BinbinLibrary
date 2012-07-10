using System.Linq.Expressions;

namespace System.Web.Mvc.Html
{
    public static class IdHtmlHelper
    {

        public static String GetIdFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {

            return TagBuilder.CreateSanitizedId(ExpressionHelper.GetExpressionText(expression));

        }

    }
}