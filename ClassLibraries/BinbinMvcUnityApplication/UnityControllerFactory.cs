using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;

namespace BinbinMvcUnityApplication
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        IUnityContainer _container;

        public UnityControllerFactory(IUnityContainer container)
        {
            _container = container;
        }
        public void RegisterControllers()
        {
            //����ǰװ�����ʵ��IContrller�ӿڵ���ע�ᵽUnity


            Type controllerType = typeof(IController);
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (controllerType.IsAssignableFrom(type))
                {
                    _container.RegisterType(type, type);
                }
            }
        }


        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }

            if (!typeof(IController).IsAssignableFrom(controllerType))
                throw new ArgumentException(string.Format(
                    "Type requested is not a controller: {0}", controllerType.Name),
                                            "controllerType");

            return _container.Resolve(controllerType) as IController;
        }
    }
}