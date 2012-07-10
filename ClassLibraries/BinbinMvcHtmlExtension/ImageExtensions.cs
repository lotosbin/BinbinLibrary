using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Routing;

namespace System.Web.Mvc.Html
{
    public static class ImageExtensions
    {
        #region lambda

        public static MvcHtmlString ImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return ImageFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var expressionText = ExpressionHelper.GetExpressionText(expression);
            htmlAttributes.Add("name", expressionText);
            return Image(htmlHelper, Convert.ToString(metadata.Model), "", htmlAttributes);
        }

        #endregion

        #region general

        /// <summary>
        ///   Images the specified helper.
        /// </summary>
        /// <param name = "helper">The helper.</param>
        /// <param name = "url">The URL.</param>
        /// <param name = "altText">The alt text.</param>
        /// <param name = "htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        /// <Author>binbin@CHENEY-NOTEBOOK 2010/4/7 13:50</Author>
        public static MvcHtmlString Image(this HtmlHelper helper,
                                          string url,
                                          string altText,
                                          object htmlAttributes)
        {
            return Image(helper, url, altText, string.Empty, string.Empty, htmlAttributes);
        }

        /// <summary>
        ///   Éú³É Img ±êÇ©
        /// </summary>
        /// <param name = "helper">The helper.</param>
        /// <param name = "url">The URL.</param>
        /// <param name = "altText">The alt text.</param>
        /// <param name = "defaultUrl">The default URL.</param>
        /// <param name = "defaultAltText">The default alt text.</param>
        /// <param name = "htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        /// <Author>binbin@CHENEY-NOTEBOOK 2010/4/7 13:50</Author>
        public static MvcHtmlString Image(this HtmlHelper helper,
                                          string url,
                                          string altText,
                                          string defaultUrl,
                                          string defaultAltText,
                                          object htmlAttributes)
        {
            return ImageHelper(
                               url,
                               altText,
                               defaultUrl,
                               defaultAltText,
                               htmlAttributes);
        }

        #endregion

        private static MvcHtmlString ImageHelper(
                string url,
                string altText,
                string defaultUrl,
                string defaultAltText,
                object htmlAttributes)
        {
            var builder = new TagBuilder("image");
            builder.Attributes.Add("src", !string.IsNullOrEmpty(url) ? url : defaultUrl);
            builder.Attributes.Add("alt", !string.IsNullOrEmpty(altText) ? altText : defaultAltText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}