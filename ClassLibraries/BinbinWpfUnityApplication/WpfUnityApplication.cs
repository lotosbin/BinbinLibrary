using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;

namespace BinbinWpfUnityApplication
{
    public class WpfUnityApplication : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var unityContainer = new UnityContainer();
            this.Properties["UnityContainer"] = unityContainer;
            RegisterTypes(unityContainer);
        }
        public static IUnityContainer UnityContainer
        {
            get
            {
                return (IUnityContainer)Application.Current.Properties["UnityContainer"];
            }
        }

        protected virtual void RegisterTypes(IUnityContainer unityContainer)
        {

        }
    }
}
