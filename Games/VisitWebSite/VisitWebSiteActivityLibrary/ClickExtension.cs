using System;
using System.Collections.Generic;
using System.Text;
using System.Activities;
using System.ComponentModel;
using mshtml;
namespace VisitWebSiteActivityLibrary
{
    [Designer(typeof(ClickDesigner))]
    public sealed class ClickExtension : CodeActivity
    {

        public InArgument<string> ClickName
        {
            get;
            set;
        }


        protected override void Execute(CodeActivityContext context)
        {
            IHTMLDocument2 doc = Browser.TheInstance.Document as IHTMLDocument2;
            IHTMLElement body = doc.body;

            IHTMLElementCollection children = body.all as IHTMLElementCollection;
            foreach (IHTMLElement child in children)
            {
                if (child == null)
                    continue;

                if (child.id != null && child.id == ClickName.Get(context))
                {
                    child.click();
                }
                else if (child.className != null && child.className == "diggit")
                {
                    child.click();
                }
            }
        }
    }
}
