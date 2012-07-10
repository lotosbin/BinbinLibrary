using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Binbin.ComponentModel.DataAnnotations;

namespace Binbin.MVC.Validations
{
    public class CompareToValidator : DataAnnotationsModelValidator<CompareToAttribute>
    {
        public CompareToValidator(ModelMetadata metadata, ControllerContext context, CompareToAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            throw new NotImplementedException();
            //// get a reference to the property this validation depends upon
            //var field = Metadata.ContainerType.GetProperty(Attribute.DependentProperty);

            //if (field != null)
            //{
            //    // get the value of the dependent property
            //    var value = field.GetValue(container, null);

            //    // compare the value against the target value
            //    if ((value == null && Attribute.TargetValue == null) ||
            //        (value.Equals(Attribute.TargetValue)))
            //    {
            //        // match => means we should try validating this field
            //        if (!Attribute.IsValid(Metadata.Model))
            //            // validation failed - return an error
            //            yield return new ModelValidationResult { Message = ErrorMessage };
            //    }
            //}
        }
    }
}