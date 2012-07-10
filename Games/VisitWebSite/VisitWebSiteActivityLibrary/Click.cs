using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using mshtml;
namespace VisitWebSiteActivityLibrary
{
    [Designer(typeof(ClickDesigner))]
    public sealed class Click : CodeActivity
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
                string clickElementName = ClickName.Get(context);
                if (child.id == clickElementName)
                {
                    child.click();
                }
                else
                {
                    IHTMLButtonElement buttonElement = child as IHTMLButtonElement;
                    IHTMLInputElement inputElement = child as IHTMLInputElement;
                    if (IsClickButtonElement(buttonElement, clickElementName))
                    {
                        child.click();
                    }
                    else if (IsClickImputElement(clickElementName, inputElement))
                    {
                        child.click();
                    }
                }
            }
        }

        private bool IsClickImputElement(string clickElementName, IHTMLInputElement inputElement)
        {
            if (inputElement == null) return false;
            if (inputElement.name == null)
            {
                return false;
            }
            return inputElement.name.Trim().ToUpper() == clickElementName.Trim().ToUpper();
        }

        private bool IsClickButtonElement(IHTMLButtonElement buttonElement, string clickElementName)
        {
            if (buttonElement == null) return false;

            if (buttonElement.name == null)
            {
                return false;
            }
            return buttonElement.name.Trim().ToUpper() == clickElementName.Trim().ToUpper();
        }
    }
    [Designer(typeof(ClickDesigner))]
    public sealed class ClickAByOnClick : CodeActivity
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

            string clickElementName = ClickName.Get(context);
            IHTMLElementCollection children = body.all as IHTMLElementCollection;
            if (children == null) return;
            foreach (IHTMLElement child in children)
            {
                if (child == null)
                    continue;
                Console.WriteLine(child.onclick);
                if (child.onclick != DBNull.Value)
                {
                    string onclicktext = child.getAttribute("onclick") as string;
                    if (!string.IsNullOrEmpty(onclicktext))
                    {


                        if (onclicktext == clickElementName)
                        {
                            var anchorElement = child as IHTMLAnchorElement;
                            if (anchorElement != null)
                            {
                                child.click();
                            }
                        }
                    }
                }
            }
        }

        private bool IsClickImputElement(string clickElementName, IHTMLInputElement inputElement)
        {
            if (inputElement == null) return false;
            if (inputElement.name == null)
            {
                return false;
            }
            return inputElement.name.Trim().ToUpper() == clickElementName.Trim().ToUpper();
        }

        private bool IsClickButtonElement(IHTMLButtonElement buttonElement, string clickElementName)
        {
            if (buttonElement == null) return false;

            if (buttonElement.name == null)
            {
                return false;
            }
            return buttonElement.name.Trim().ToUpper() == clickElementName.Trim().ToUpper();
        }
    }
}
