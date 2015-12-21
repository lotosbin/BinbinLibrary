using Microsoft.Practices.Unity;
using System.Windows;

namespace BinbinWpfUnityApplication {
    public class WpfUnityApplication : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            var unityContainer = new UnityContainer();
            this.Properties["UnityContainer"] = unityContainer;
            RegisterTypes(unityContainer);
        }
        public static IUnityContainer UnityContainer => (IUnityContainer)Application.Current.Properties["UnityContainer"];

        protected virtual void RegisterTypes(IUnityContainer unityContainer) {

        }
    }
}
