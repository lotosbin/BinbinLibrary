using System;
using System.Web;

namespace BinbinTopAuth
{
    public class BinbinTopAuthModule : IHttpModule
    {
        public BinbinTopAuthModule()
        {
        }

        public String ModuleName
        {
            get { return "BinbinTopAuthModule"; }
        }

        // In the Init function, register for HttpApplication 
        // events by adding your handlers.
        public void Init(HttpApplication application)
        {
            application.BeginRequest +=
                (new EventHandler(this.Application_BeginRequest));
            application.EndRequest +=
                (new EventHandler(this.Application_EndRequest));
            application.PreRequestHandlerExecute+=new EventHandler(application_PreRequestHandlerExecute);
        }

        private void application_PreRequestHandlerExecute(object source, EventArgs e)
        {
            // Create HttpApplication and HttpContext objects to access
            // request and response properties.
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            var code = context.Request.Params["code"];
            if (!string.IsNullOrEmpty(code))
            {
                //var token = BinbinTopAuthentication.GetToken(code);
                context.Session["TopCode"] = code;
                //context.Session["TopToken"] = token;
            }
        }

        private void Application_BeginRequest(Object source,
                                              EventArgs e)
        {
            
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write("<hr><h1><font color=red>" +
                                       "HelloWorldModule: End of Request</font></h1>");
            }
        }

        public void Dispose() { }
    }
}