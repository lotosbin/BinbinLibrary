using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Web.Mvc.Html
{
    public static class TextBoxIdExtension
    {
        private static string InputIdHelper(HtmlHelper htmlHelper, InputType inputType, ModelMetadata metadata, string name, object value, bool useViewData, bool isChecked, bool setId, bool isExplicitValue, IDictionary<string, object> htmlAttributes)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("name");
            }

            TagBuilder tagBuilder = new TagBuilder("input");



            if (setId)
            {
                tagBuilder.GenerateId(fullName);
                return tagBuilder.Attributes["id"];
            }

            return string.Empty;

        }
        private static string TextBoxIdHelper(this HtmlHelper htmlHelper, ModelMetadata metadata, object model, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputIdHelper(htmlHelper, InputType.Text, metadata, expression, model, false /* useViewData */, false /* isChecked */, true /* setId */, true /* isExplicitValue */, htmlAttributes);
        }
        public static string TextBoxIdFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return TextBoxIdHelper(htmlHelper,
                                   metadata,
                                   metadata.Model,
                                   ExpressionHelper.GetExpressionText(expression),
                                   htmlAttributes);
        }
        public static string TextBoxIdFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.TextBoxIdFor(expression, (IDictionary<string, object>)null);
        }
    }
}