using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using mshtml;
namespace VisitWebSiteActivityLibrary
{
    [Designer(typeof(InputDataDesigner))]
    public sealed class InputData : CodeActivity
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
            IHTMLElement body = doc.body;

            IHTMLElementCollection children = body.all as IHTMLElementCollection;
            foreach (IHTMLElement child in children)
            {
                if (child == null)
                    continue;


                IHTMLInputElement inputElement = child as IHTMLInputElement;

                if (inputElement != null && inputElement.name != null && inputElement.name.Trim().ToUpper() == InputName.Get(context).Trim().ToUpper())
                {

                    switch (Type.Get(context))
                    {
                        case INPUT_TYPE_TEXT:
                            inputElement.value = Value.Get(context);
                            break;
                        case INPUT_TYPE_RADIO:
                        case INPUT_TYPE_CHECK:
                            inputElement.@checked = Boolean.Parse(Value.Get(context));
                            break;
                    }
                    break;
                }

                IHTMLTextAreaElement textAreaElement = child as IHTMLTextAreaElement;
                if (textAreaElement != null
                    && textAreaElement.name != null
                    && inputElement != null
                    && inputElement.name != null
                    && inputElement.name.Trim().ToUpper() == InputName.Get(context).Trim().ToUpper())
                    textAreaElement.value = Value.Get(context);

                IHTMLSelectElement selectElement = child as IHTMLSelectElement;

                if (selectElement != null && selectElement.name.Trim().ToUpper() == InputName.Get(context).Trim().ToUpper())//_name.Trim().ToUpper())
                {
                    HTMLOptionElement option = null;
                    for (int i = 0; i < selectElement.length; i++)
                    {
                        option = selectElement.item(i, i) as HTMLOptionElement;
                        if (option == null)
                            continue;
                        if (option.value != null && option.value.Trim().ToUpper() == Value.Get(context).Trim().ToUpper())
                        {
                            selectElement.selectedIndex = i;
                            break;
                        }
                        else if (option.text.Trim().ToUpper() == Value.Get(context).Trim().ToUpper())
                        {
                            selectElement.selectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }
    }
}
