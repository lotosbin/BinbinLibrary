using System;
using System.Activities;
using System.ComponentModel;
using mshtml;

namespace VisitWebSiteActivityLibrary
{
    [Designer(typeof(InputDataDesigner))]
    public sealed class SetInputValueWitchInDivByDivId : CodeActivity
    {
        private const string INPUT_TYPE_TEXT = "TEXT";
        private const string INPUT_TYPE_RADIO = "RADIO";
        private const string INPUT_TYPE_CHECK = "CHECKBOX";

        public InArgument<string> Type
        {
            get;
            set;
        }



        public InArgument<string> InputName
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
            if (doc != null)
            {
                IHTMLElement body = doc.body;

                if (body != null)
                {
                    IHTMLElementCollection children = body.all as IHTMLElementCollection;
                    string divId = InputName.Get(context);
                    string value = Value.Get(context);
                    if (children == null) return;
                    foreach (IHTMLElement child in children)
                    {
                        if (child == null)
                            continue;
                        if (child.id == divId)
                        {
                            var divElement = child as IHTMLDivElement;
                            if (null == divElement) continue;
                            IHTMLElementCollection divAll = child.all as IHTMLElementCollection;
                            if (divAll == null)
                            {
                                continue;
                            }
                            foreach (IHTMLElement divitem in divAll)
                            {
                                IHTMLInputElement inputElement = divitem as IHTMLInputElement;

                                if (inputElement != null)
                                {
                                    switch (Type.Get(context))
                                    {
                                        case INPUT_TYPE_TEXT:
                                            inputElement.value = value;
                                            break;
                                        case INPUT_TYPE_RADIO:
                                        case INPUT_TYPE_CHECK:
                                            inputElement.@checked = Boolean.Parse(value);
                                            break;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}