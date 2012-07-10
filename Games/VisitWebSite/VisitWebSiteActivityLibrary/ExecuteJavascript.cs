using System;
using System.Activities;
using System.ComponentModel;
using mshtml;

namespace VisitWebSiteActivityLibrary
{
    [Designer(typeof(ClickDesigner))]
    public sealed class ExecuteJavascript : CodeActivity
    {

        public InArgument<string> ClickName
        {
            get;
            set;
        }


        protected override void Execute(CodeActivityContext context)
        {
            {

                string clickElementName = ClickName.Get(context);
                Console.WriteLine("executeScript:" + clickElementName);
                IHTMLDocument2 doc = Browser.TheInstance.Document as IHTMLDocument2;
                try
                {
                    IHTMLWindow2 win = doc.parentWindow;
                    doc.parentWindow.window.execScript(clickElementName, "Javascript");
                    win.execScript(clickElementName, "Javascript");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }


    }
}