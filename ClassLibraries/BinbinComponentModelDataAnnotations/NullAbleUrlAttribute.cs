using System;
using System.ComponentModel.DataAnnotations;

namespace Binbin.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NullAbleUrlAttribute : ValidationAttribute
    {
        public NullAbleUrlAttribute()
        {
        }

        public bool NeedProtocol
        {
            get;
            set;
        }

        public override bool IsValid(object value)
        {
            var text = value as string;
            if (string.IsNullOrEmpty(text))
                return true;
            Uri uri;
            if (NeedProtocol)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    var lower = text.ToLower();
                    if (!(lower.StartsWith("http://")|| lower.StartsWith("https://")))
                    {
                        text = "http://" + text;
                    }
                }
            }
            return (Uri.TryCreate(text, UriKind.Absolute, out uri));
        }
    }
}
