using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System.Web.Mvc.Html
{
    public static class FileExtensions
    {
        /// <summary>
        /// Returns a file input element by using the specified HTML helper and the name of the form field.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field.</param>
        /// <returns>An input element that has its type attribute set to "file".</returns>
        public static MvcHtmlString File(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.FileHelper(name, null);
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <returns>An input element that has its type attribute set to "file".</returns>
        public static MvcHtmlString File(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return htmlHelper.FileHelper(name, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <returns>
        /// An input element that has its type attribute set to "file".
        /// </returns>
        public static MvcHtmlString File(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.FileHelper(name, htmlAttributes);
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper and the name of the form field.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>
        /// An input element that has its type attribute set to "file".
        /// </returns>
        public static MvcHtmlString FileFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.FileHelper(ExpressionHelper.GetExpressionText(expression), null);
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <returns>
        /// An input element that has its type attribute set to "file".
        /// </returns>
        public static MvcHtmlString FileFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return htmlHelper.FileHelper(ExpressionHelper.GetExpressionText(expression), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <returns>
        /// An input element that has its type attribute set to "file".
        /// </returns>
        public static MvcHtmlString FileFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.FileHelper(ExpressionHelper.GetExpressionText(expression), htmlAttributes);
        }

        private static MvcHtmlString FileHelper(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
        {
            string fieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("type", "file", true);
            tagBuilder.MergeAttribute("name", fieldName, true);
            tagBuilder.GenerateId(fieldName);

            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(name, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }
    }
    //public static class HtmlHelperExtensions
    //{


    //    /// <summary>
    //    ///   生成 a>img 标签
    //    /// </summary>
    //    /// <param name = "helper">The helper.</param>
    //    /// <param name = "url">The URL.</param>
    //    /// <param name = "altText">The alt text.</param>
    //    /// <param name = "defaultUrl">The default URL.</param>
    //    /// <param name = "defaultAltText">The default alt text.</param>
    //    /// <param name = "imageHtmlAttributes">The image HTML attributes.</param>
    //    /// <param name = "actionName">Name of the action.</param>
    //    /// <param name = "controllerName">Name of the controller.</param>
    //    /// <param name = "routeValues">The route values.</param>
    //    /// <param name = "linkHtmlAttributes">The link HTML attributes.</param>
    //    /// <returns></returns>
    //    /// <Author>binbin@CHENEY-NOTEBOOK 2010/4/8 10:37</Author>
    //    public static string ActionImageLink(this HtmlHelper helper, string url, string altText, string defaultUrl,
    //                                         string defaultAltText, object imageHtmlAttributes, string actionName,
    //                                         string controllerName,
    //                                         object routeValues, object linkHtmlAttributes)
    //    {
    //        string image = helper.Image(url, altText, defaultUrl, defaultAltText, imageHtmlAttributes).ToString();
    //        MvcHtmlString link = helper.ActionLink("[replaceme]",
    //                                               actionName,
    //                                               controllerName,
    //                                               routeValues,
    //                                               linkHtmlAttributes);
    //        return link.ToString().Replace("[replaceme]", image);
    //    }

    //    /// <summary>
    //    /// Actions the link.
    //    /// </summary>
    //    /// <param name="htmlHelper">The HTML helper.</param>
    //    /// <param name="linkText">The link text.</param>
    //    /// <param name="defaultLinkText">The default link text.</param>
    //    /// <param name="actionName">Name of the action.</param>
    //    /// <param name="controllerName">Name of the controller.</param>
    //    /// <param name="routeValues">The route values.</param>
    //    /// <param name="htmlAttributes">The HTML attributes.</param>
    //    /// <returns></returns>
    //    /// <Author>binbin@CHENEY-NOTEBOOK 2010/4/15 10:44</Author>
    //    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string defaultLinkText,
    //                                           string actionName,
    //                                           string controllerName, object routeValues, object htmlAttributes)
    //    {
    //        string rLinkText = string.IsNullOrEmpty(linkText) ? defaultLinkText : linkText;
    //        if (string.IsNullOrEmpty(rLinkText))
    //        {
    //            rLinkText = " ";
    //        }
    //        return htmlHelper.ActionLink(rLinkText,
    //                                     actionName,
    //                                     controllerName,
    //                                     routeValues,
    //                                     htmlAttributes);
    //    }
    //}
    //public static class ImageExtensions
    //{
    //    #region lambda

    //    public static MvcHtmlString ImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
    //    {
    //        return ImageFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    //    }

    //    public static MvcHtmlString ImageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
    //    {
    //        ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
    //        var expressionText = ExpressionHelper.GetExpressionText(expression);
    //        htmlAttributes.Add("name", expressionText);
    //        return Image(htmlHelper, Convert.ToString(metadata.Model), "", htmlAttributes);
    //    }

    //    #endregion

    //    #region general

    //    /// <summary>
    //    ///   Images the specified helper.
    //    /// </summary>
    //    /// <param name = "helper">The helper.</param>
    //    /// <param name = "url">The URL.</param>
    //    /// <param name = "altText">The alt text.</param>
    //    /// <param name = "htmlAttributes">The HTML attributes.</param>
    //    /// <returns></returns>
    //    /// <Author>binbin@CHENEY-NOTEBOOK 2010/4/7 13:50</Author>
    //    public static MvcHtmlString Image(this HtmlHelper helper,
    //                               string url,
    //                               string altText,
    //                               object htmlAttributes)
    //    {
    //        return Image(helper, url, altText, string.Empty, string.Empty, htmlAttributes);
    //    }

    //    /// <summary>
    //    ///   生成 Img 标签
    //    /// </summary>
    //    /// <param name = "helper">The helper.</param>
    //    /// <param name = "url">The URL.</param>
    //    /// <param name = "altText">The alt text.</param>
    //    /// <param name = "defaultUrl">The default URL.</param>
    //    /// <param name = "defaultAltText">The default alt text.</param>
    //    /// <param name = "htmlAttributes">The HTML attributes.</param>
    //    /// <returns></returns>
    //    /// <Author>binbin@CHENEY-NOTEBOOK 2010/4/7 13:50</Author>
    //    public static MvcHtmlString Image(this HtmlHelper helper,
    //                               string url,
    //                               string altText,
    //                               string defaultUrl,
    //                               string defaultAltText,
    //                               object htmlAttributes)
    //    {
    //        return ImageHelper(
    //                           url,
    //                           altText,
    //                           defaultUrl,
    //                           defaultAltText,
    //                           htmlAttributes);
    //    }

    //    #endregion

    //    private static MvcHtmlString ImageHelper(
    //                          string url,
    //                          string altText,
    //                          string defaultUrl,
    //                          string defaultAltText,
    //                          object htmlAttributes)
    //    {
    //        var builder = new TagBuilder("image");
    //        builder.Attributes.Add("src", !string.IsNullOrEmpty(url) ? url : defaultUrl);
    //        builder.Attributes.Add("alt", !string.IsNullOrEmpty(altText) ? altText : defaultAltText);
    //        builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
    //        return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
    //    }
    //}
}
