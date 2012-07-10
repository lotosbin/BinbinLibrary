using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Binbin.Practics.EnterpriseLibrary.Validataion
{
    public static class EntLibValidationExtensions
    {
        public static void CopyToModelState(this ValidationResults results, ModelStateDictionary modelState)
        {
            foreach (var result in results)
                modelState.AddModelError(result.Key ?? "_FORM", result.Message);
        }
    }
}