using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using mshtml;
namespace VisitWebSiteActivityLibrary
{
    [Designer(typeof(InputDataExtensionDesigner))]
    public sealed class InputDataExtension : CodeActivity
    {
        private const string INPUT_TYPE_TEXT = "TEXT";
        private const string INPUT_TYPE_RADIO = "RADIO";
        private const string INPUT_TYPE_CHECK = "CHECKBOX";

        public InArgument<string> Type
        {
            get ; 
            set ; 
        }

        public InArgument<string> InputID
        {
            get;
            set;
        }



        public InArgument<string> Value
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
                if (child.id != null && child.id == InputID.Get(context))
                {
                    child.innerText = Value.Get(context);
                }

            }
        }
    }
}
