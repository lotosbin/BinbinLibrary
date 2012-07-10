using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Binbin.Practics.EnterpriseLibrary.Validataion
{
    public class MyModelBinder : DefaultModelBinder
    {
        /*最後在global.asax.cs 中的Application_Start 設定一下，加入

ModelBinders.Binders.DefaultBinder = new MyModelBinder();*/
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //base.OnModelUpdated(controllerContext, bindingContext);

            ValidatorFactory factory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            var validator = factory.CreateValidator(bindingContext.ModelType);

            Dictionary<string, bool> startedValid = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

            foreach (var result in validator.Validate(bindingContext.Model))
            {
                string subPropertyName = CreateSubPropertyName(bindingContext.ModelName, result.Key);

                if (!startedValid.ContainsKey(subPropertyName))
                {
                    startedValid[subPropertyName] = bindingContext.ModelState.IsValidField(subPropertyName);
                }

                if (startedValid[subPropertyName])
                {
                    bindingContext.ModelState.AddModelError(subPropertyName, result.Message);
                }
            }
        }

       
    }


}
