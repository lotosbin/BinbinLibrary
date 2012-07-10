using System.Windows;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.Unity;

namespace WebScan.WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void CreateContainer(object sender, StartupEventArgs e)
        {
            var container = new UnityContainer()
                .AddNewExtension<EnterpriseLibraryCoreExtension>();
            var window = container.Resolve<MainWindow>();
            window.Show();
        }

    }
}
