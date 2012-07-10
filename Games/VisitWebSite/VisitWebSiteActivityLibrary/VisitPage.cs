using System.Activities;
using System.ComponentModel;
using System.Threading;
using Microsoft.ShDocVw;

namespace VisitWebSiteActivityLibrary
{
    [Designer(typeof(VisitPageDesigner))]
    public sealed class VisitPage : CodeActivity
    {
        public InArgument<string> Url
        {
            get;
            set;
        }


        public InArgument<int> WaitTime
        {
            get;
            set;
        }
        public InArgument<IWebBrowser2> BrowserInstance { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            object missing = System.Reflection.Missing.Value;
            string url = Url.Get(context);
            IWebBrowser2 theInstance = Browser.TheInstance;
            theInstance.Navigate(url, ref missing, ref missing, ref missing, ref missing);
            theInstance.Visible = true;
            while (theInstance.Busy)
            {
                int millisecondsTimeout = WaitTime.Get(context);
                Thread.Sleep(millisecondsTimeout);
            }
        }
    }
}
