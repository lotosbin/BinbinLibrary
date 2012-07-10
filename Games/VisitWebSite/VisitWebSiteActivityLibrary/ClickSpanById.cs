using System.Activities;
using System.ComponentModel;
using mshtml;

namespace VisitWebSiteActivityLibrary
{
    [Designer(typeof(ClickDesigner))]
    public sealed class ClickSpanById : CodeActivity
    {

        public InArgument<string> ClickName
        {
            get;
            set;
        }


        protected override void Execute(CodeActivityContext context)
        {
            string clickName = ClickName.Get(context);
            IHTMLDocument2 doc = Browser.TheInstance.Document as IHTMLDocument2;
            IHTMLElement body = doc.body;

            IHTMLElementCollection children = body.all as IHTMLElementCollection;
            foreach (IHTMLElement child in children)
            {
                if (child == null)
                    continue;

                if (child.id != null && child.id == clickName)
                {
                    child.click();
                }

            }
        }
    }
}