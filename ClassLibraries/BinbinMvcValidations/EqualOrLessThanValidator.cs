using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Binbin.ComponentModel.DataAnnotations;

namespace Binbin.MVC.Validations
{
    public class EqualOrLessThanValidator : DataAnnotationsModelValidator<EqualOrLessThanAttribute>
    {
        public EqualOrLessThanValidator(ModelMetadata metadata, ControllerContext context, EqualOrLessThanAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            // get a reference to the property this validation depends upon
            var dependentProperty = Attribute.DependentProperty;
            var propertyName = this.Metadata.PropertyName;
            var dependentField = Metadata.ContainerType.GetProperty(dependentProperty);
            var field = this.Metadata.ContainerType.GetProperty(propertyName);
            if (dependentField == null)
            {
                throw new Exception("Dependent Property " + dependentProperty + "Not Exist");
            }
            if (field == null)
            {
                throw new Exception("Property " + propertyName + " Not Exist");
            }
            // get the value of the dependent property
            var dependentValue = dependentField.GetValue(container, null);
            var value = field.GetValue(container, null);
            if (value is decimal && dependentValue is decimal)
            {
                if ((decimal)value <= (decimal)dependentValue)
                {

                    if (!Attribute.IsValid(this.Metadata.Model))
                    {
                        yield return new ModelValidationResult() { Message = ErrorMessage };
                    }
                }
                else
                {
                    yield return new ModelValidationResult() { Message = ErrorMessage };
                }
            }

            else if (value is double && dependentValue is double)
            {
                if ((double)value <= (double)dependentValue)
                {

                    if (!Attribute.IsValid(this.Metadata.Model))
                    {
                        yield return new ModelValidationResult() { Message = ErrorMessage };
                    }
                }
                else
                {
                    yield return new ModelValidationResult() { Message = ErrorMessage };
                }
            }
            else
            {
                throw new Exception("属性类型不一致");
            }
        }
    }
}