using System;
using System.ComponentModel.DataAnnotations;

namespace Binbin.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UrlAttribute : ValidationAttribute
    {
        public UrlAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var text = value as string;
            Uri uri;

            return (!string.IsNullOrWhiteSpace(text) && Uri.TryCreate(text, UriKind.Absolute, out uri));
        }
    }
}