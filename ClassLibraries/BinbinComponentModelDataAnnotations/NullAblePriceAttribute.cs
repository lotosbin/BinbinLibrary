using System;
using System.ComponentModel.DataAnnotations;

namespace Binbin.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NullAblePriceAttribute : ValidationAttribute
    {
        public NullAblePriceAttribute()
        {
        }
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            else
            {
                var text = value.ToString();
                decimal tempPrice;
                if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out tempPrice) && tempPrice > 0)
                    return true;
                return false;
            }
        }
    }
}
