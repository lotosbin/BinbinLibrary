using System.Activities;
using System.ComponentModel;
using System.Linq;
using mshtml;

namespace VisitWebSiteActivityLibrary
{
    [Designer(typeof(ClickDesigner))]
    public sealed class ClickFirstChildDivByParentClass : CodeActivity
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

                string clickName = ClickName.Get(context);
                var divElement = child as IHTMLDivElement;
                if (null != divElement
                    && child.className == clickName)
                {
                    IHTMLElementCollection collection = child.children as IHTMLElementCollection;
                    IHTMLElement htmlElement = collection.OfType<IHTMLElement>().First();
                    htmlElement.click();
                } if (child.style.toString().ToUpper() == clickName.ToUpper())
                {
                    child.click();
                }
                if (child.id != null && child.id == clickName)
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