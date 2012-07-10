using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BinbinMvcRazorTemplates.Helpers
{


    public static class TemplateViewModelExtension
    {
        public static object GetModelValueForHiddenInput(this object Model)
        {
            if (Model is Binary)
            {
                return Convert.ToBase64String(((Binary)Model).ToArray());
            }
            if (Model is byte[])
            {
                return Convert.ToBase64String((byte[])Model);
            }
            return Model;
        }
        public static object GetModelValueForDecimal<TModel>(this WebViewPage<TModel> page)
        {

            {
                if (page.ViewData.TemplateInfo.FormattedModelValue == page.ViewData.ModelMetadata.Model)
                {
                    return String.Format(System.Globalization.CultureInfo.CurrentCulture,
                                         "{0:0.00}", page.ViewData.ModelMetadata.Model);
                }
                return page.ViewData.TemplateInfo.FormattedModelValue;
            }
        }

        public static List<SelectListItem> BooleanGetTriStateValues<TModel>(this WebViewPage<TModel> page)
        {

            {
                bool hasValue = page.BooleanGetValue().HasValue;
                return new List<SelectListItem> {
                new SelectListItem { Text = "Not Set",
                                     Value = String.Empty,
                                     Selected = !hasValue },
                new SelectListItem { Text = "True",
                                     Value = "true",
                                     Selected = hasValue && page.BooleanGetValue().Value },
                new SelectListItem { Text = "False",
                                     Value = "false",
                                     Selected = hasValue && !page.BooleanGetValue().Value },
            };
            }
        }

        public static bool? BooleanGetValue<TModel>(this WebViewPage<TModel> page)
        {

            {
                bool? value = null;
                if (page.ViewData.Model != null)
                {
                    value = Convert.ToBoolean(page.ViewData.Model,
                                              System.Globalization.CultureInfo.InvariantCulture);
                }
                return value;
            }
        }
        public static bool? BooleanGetModelValue<TModel>(this WebViewPage<TModel> page)
        {

            {
                bool? value = null;
                if (page.ViewData.Model != null)
                {
                    value = Convert.ToBoolean(page.ViewData.Model, System.Globalization.CultureInfo.InvariantCulture);
                }
                return value;
            }
        }

        public static object DecimalGetFormattedValue<TModel>(this WebViewPage<TModel> page)
        {

            {
                if (page.ViewData.TemplateInfo.FormattedModelValue == page.ViewData.ModelMetadata.Model)
                {
                    return String.Format(System.Globalization.CultureInfo.CurrentCulture,
                                         "{0:0.00}",
                                         page.ViewData.ModelMetadata.Model);
                }
                return page.ViewData.TemplateInfo.FormattedModelValue;
            }
        }
    }


}