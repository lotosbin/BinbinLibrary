using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BinbinMvcControllerExtensionForNet4Mvc3
{
    public static class ControllerExtension
    {
        public static bool IsPost(this Controller controller)
        {
            return controller.Request.HttpMethod == "POST";
        }

        public static bool IsGet(this Controller controller)
        {
            return controller.Request.HttpMethod == "GET";
        }
        public static bool IsAjaxRequest(this Controller controller)
        {
            return controller.Request.IsAjaxRequest();
        }

        public static bool IsChildAction(this Controller controller)
        {
            return controller.ControllerContext.IsChildAction;
        }
        public static bool IsAcceptJson(this Controller controller)
        {
            IEnumerable<string> acceptTypes = controller.Request.AcceptTypes.AsEnumerable();
            return acceptTypes.Contains("application/json") || acceptTypes.Contains("text/json");
        }

        public static bool IsAcceptHtml(this Controller controller)
        {
            IEnumerable<string> acceptTypes = controller.Request.AcceptTypes.AsEnumerable();
            return acceptTypes.Contains("application/html") || acceptTypes.Contains("text/html");
        }

        public static bool IsIE7(this Controller controller)
        {
            /*Version token	Description
MSIE 8.0	Internet Explorer 8 (pre-release)
MSIE 7.0	Internet Explorer 7
MSIE 7.0b	Internet Explorer 7 (Beta 1 pre-release only)
MSIE 6.0	Microsoft Internet Explorer 6
MSIE 6.0b	Internet Explorer 6 (pre-release)
MSIE 5.5	Internet Explorer 5.5
MSIE 5.01	Internet Explorer 5.01
MSIE 5.0	Internet Explorer 5
MSIE 5.0b1	Internet Explorer 5 (pre-release)
MSIE 4.01	Internet Explorer 4.01*/
            return controller.Request.UserAgent.Contains("MSIE 7.0");
        }
        public static bool IsIE6(this Controller controller)
        {
            return controller.Request.UserAgent.Contains("MSIE 6.0");
        }

    }
    //public static class ChildActionExtension
    //{
    //    public static void RenderAction(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, bool hidden)
    //    {
    //        if (!hidden)
    //        {
    //            htmlHelper.RenderAction(actionName, controllerName, routeValues);
    //        }
    //        return;
    //    }
    //}
    public static class ModelStateDictionaryExtension
    {
        public static string ToText(this ModelStateDictionary modelStates)
        {
            var message = string.Empty;
            foreach (var modelState in modelStates.Values)
            {
                if (modelState.Errors.Count > 0)
                {
                    message = modelState.Errors[0].ErrorMessage;
                    break;
                }
            }
            return message;
        }
    }
}
