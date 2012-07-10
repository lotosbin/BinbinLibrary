using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Binbin.TextTemplate
{
    public class TextTemplateTranformer
    {
        public static string TransformTemplate(string bodyTemplate, List<KeyValuePair<string, string>> bargs)
        {
            string mailBody = bodyTemplate;
            foreach (var arg in bargs)
            {
                mailBody = mailBody.Replace("{{" + arg.Key + "}}", arg.Value);

            }
            return mailBody;
        }
    }
}
