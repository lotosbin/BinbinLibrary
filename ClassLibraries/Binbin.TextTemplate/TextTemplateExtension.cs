using System.Collections.Generic;

namespace Binbin.TextTemplate
{
    public static class TextTemplateExtension
    {
        public static string Transform(this string template, List<KeyValuePair<string, string>> bargs)
        {
            return TextTemplateTranformer.TransformTemplate(template, bargs);
        }
    }
}