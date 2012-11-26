using System.Web;

namespace BinbinHttpModules.Log4Net
{
    public abstract class ApplicationStartModuleBase : IHttpModule
    {
        #region Static privates

        private static volatile bool applicationStarted = false;
        private static object applicationStartLock = new object();

        #endregion

        #region IHttpModule implementation

        /// <summary>
        ///     Initializes the specified module.
        /// </summary>
        /// <param name="context">The application context that instantiated and will be running this module.</param>
        public virtual void Init(HttpApplication context)
        {
            if (!applicationStarted)
            {
                lock (applicationStartLock)
                {
                    if (!applicationStarted)
                    {
                        // this will run only once per application start
                        Start(context);
                        applicationStarted = true;
                    }
                }
            }
        }

        /// <summary>
        ///     Disposes of the resources (other than memory) used by the module that implements
        ///     <see
        ///         cref="T:System.Web.IHttpModule" />
        ///     .
        /// </summary>
        public void Dispose()
        {
            // dispose any resources if needed
        }

        #endregion

        /// <summary>Initializes any data/resources on application start.</summary>
        /// <param name="context">The application context that instantiated and will be running this module.</param>
        public virtual void Start(HttpApplication context)
        {
            // put your application start code here
        }
    }
}