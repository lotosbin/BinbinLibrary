using System.Collections.Generic;
using System.Linq;

namespace Binbin.TextTemplate {
    public class TextTemplateTranformer {
        public static string TransformTemplate(string bodyTemplate, List<KeyValuePair<string, string>> bargs) {
            return bargs.Aggregate(bodyTemplate, (current, arg) => current.Replace("{{" + arg.Key + "}}", arg.Value));
        }
    }
}
