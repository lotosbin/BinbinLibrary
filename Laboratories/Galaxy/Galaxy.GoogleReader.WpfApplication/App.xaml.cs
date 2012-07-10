using System.Windows;
using Galaxy.DynamicControl.Core.Common;
using Galaxy.GoogleReader.Client.Models.UserInfo;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.Unity;

namespace Galaxy.GoogleReader.WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void CreateContainer(object sender, StartupEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            //var editorProfile = new EditorProfile<UserInfoJson>();
            //var editorHelper = new DynamicEditorHelper<UserInfoJson>
            //                       {
            //                           EditorProfile = editorProfile
            //                       };
            //var windowUserInfo = new WindowUserInfo();
            //editorHelper.Initialize(windowUserInfo);
            //windowUserInfo.ShowDialog();
        }
    }
}