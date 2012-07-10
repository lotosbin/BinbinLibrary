namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExtensions
    {


        /// <summary>
        ///   …˙≥… a>img ±Í«©
        /// </summary>
        /// <param name = "helper">The helper.</param>
        /// <param name = "url">The URL.</param>
        /// <param name = "altText">The alt text.</param>
        /// <param name = "defaultUrl">The default URL.</param>
        /// <param name = "defaultAltText">The default alt text.</param>
        /// <param name = "imageHtmlAttributes">The image HTML attributes.</param>
        /// <param name = "actionName">Name of the action.</param>
        /// <param name = "controllerName">Name of the controller.</param>
        /// <param name = "routeValues">The route values.</param>
        /// <param name = "linkHtmlAttributes">The link HTML attributes.</param>
        /// <returns></returns>
        /// <Author>binbin@CHENEY-NOTEBOOK 2010/4/8 10:37</Author>
        public static string ActionImageLink(this HtmlHelper helper, string url, string altText, string defaultUrl,
                                             string defaultAltText, object imageHtmlAttributes, string actionName,
                                             string controllerName,
                                             object routeValues, object linkHtmlAttributes)
        {
            string image = helper.Image(url, altText, defaultUrl, defaultAltText, imageHtmlAttributes).ToString();
            MvcHtmlString link = helper.ActionLink("[replaceme]",
                                                   actionName,
                                                   controllerName,
                                                   routeValues,
                                                   linkHtmlAttributes);
            return link.ToString().Replace("[replaceme]", image);
        }

        /// <summary>
        /// Actions the link.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="defaultLinkText">The default link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        /// <Author>binbin@CHENEY-NOTEBOOK 2010/4/15 10:44</Author>
        public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string defaultLinkText,
                                               string actionName,
                                               string controllerName, object routeValues, object htmlAttributes)
        {
            string rLinkText = string.IsNullOrEmpty(linkText) ? defaultLinkText : linkText;
            if (string.IsNullOrEmpty(rLinkText))
            {
                rLinkText = " ";
            }
            return htmlHelper.ActionLink(rLinkText,
                                         actionName,
                                         controllerName,
                                         routeValues,
                                         htmlAttributes);
        }
    }
}