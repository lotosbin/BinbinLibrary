using System;
using System.ComponentModel.DataAnnotations;

namespace Binbin.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EqualOrLessThanAttribute:ValidationAttribute
    {
        public EqualOrLessThanAttribute(string dependentProperty )
        {
            DependentProperty = dependentProperty;
        }


        public string DependentProperty { get; set; }
        public override bool IsValid(object value)
        {
            return true;
        }
    }
}