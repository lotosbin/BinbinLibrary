using System.Windows;
using GalaxyAutoEntity.WpfApplication.GalaxyMemoryDatabase;

namespace GalaxyAutoEntity.WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MemoryDatabaseServer.Instances["GMDB1.0"].CreateTable("Users");
        }
    }
}
