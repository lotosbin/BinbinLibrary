using System;
using System.ComponentModel.DataAnnotations;

namespace Binbin.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CompareToAttribute:ValidationAttribute
    {
        public CompareToAttribute(string dependentProperty)
        {
            DependentProperty = dependentProperty;
        }


        public string DependentProperty { get; set; }
    }
}