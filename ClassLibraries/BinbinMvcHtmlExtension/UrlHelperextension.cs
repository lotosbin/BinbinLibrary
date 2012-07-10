using System.Web.Routing;

namespace System.Web.Mvc.Html
{
    public static class UrlHelperextension
    {
        public static RouteValueDictionary Merge(this RouteValueDictionary original, RouteValueDictionary @new)
        {

            // Create a new dictionary containing implicit and auto-generated values
            RouteValueDictionary merged = new RouteValueDictionary(original);

            foreach (var f in @new)
            {
                if (merged.ContainsKey(f.Key))
                {
                    merged[f.Key] = f.Value;
                }
                else
                {
                    merged.Add(f.Key, f.Value);
                }
            }

            return merged;

        }
        public static string Action(this UrlHelper helper, string action, string controller, string area, object routeValues)
        {
            var routeValueDictionary = new RouteValueDictionary(routeValues);
            return Action(helper, action, controller, area, routeValueDictionary);
        }

        public static string Action(UrlHelper helper, string action, string controller, string area, RouteValueDictionary routeValues)
        {
            return helper.Action(action, controller, new RouteValueDictionary(new { area = area }).Merge(routeValues));
        }
    }
}