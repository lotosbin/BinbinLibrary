using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace BinbinMvcUnityApplication
{
    public class MvcUnityApplication : HttpApplication, IContainerAccessor
    {
        public IUnityContainer Container { get; set; }

        private void InitContainer()
        {
            this.Container = UnityContainerInstance.Instance;
        }
        private void registerControllerFactory()
        {
            var unityContainer = UnityContainerInstance.Instance;
            var ymatouControllerFactory = new UnityControllerFactory(unityContainer);
            ymatouControllerFactory.RegisterControllers();
            ControllerBuilder.Current.SetControllerFactory(ymatouControllerFactory);
        }

        protected virtual void Application_Start()
        {
            //init unity container
            InitContainer();
            //register types
            IUnityContainer container = UnityContainerInstance.Instance;
            this.RegisterTypes(container);
            //register UnityControllerFactory
            registerControllerFactory();
        }

        protected virtual void RegisterTypes(IUnityContainer container)
        {

        }
    }
}