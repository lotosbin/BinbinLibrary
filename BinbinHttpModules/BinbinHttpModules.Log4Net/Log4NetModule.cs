using System;
using System.Web;
using log4net;

namespace BinbinHttpModules.Log4Net
{
    public class Log4NetModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.Error += Application_Error;
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = HttpContext.Current.Server.GetLastError().GetBaseException();
            ILog log = LogManager.GetLogger(typeof (Log4NetModule));
            log.Error("global", exception);
        }
    }
}