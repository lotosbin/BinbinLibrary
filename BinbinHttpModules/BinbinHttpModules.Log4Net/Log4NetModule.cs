using System;
using System.Web;
using log4net;
using log4net.Config;

namespace BinbinHttpModules.Log4Net
{
    public class Log4NetModule : ApplicationStartModuleBase
    {
        public override void Start(HttpApplication context)
        {
            base.Start(context);
            XmlConfigurator.Configure();
        }

        public override void Init(HttpApplication context)
        {
            base.Init(context);
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