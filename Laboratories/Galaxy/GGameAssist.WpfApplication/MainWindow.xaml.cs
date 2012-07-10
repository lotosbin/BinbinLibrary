using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GGameAssist.WpfApplication.Models;

namespace GGameAssist.WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonLoginTest_Click(object sender, RoutedEventArgs e)
        {
            var websiteModel = new BaiduWebsiteModel(webBrowser1);
            string loginUrl = this.textBoxLoginUrl.Text;
            string username = this.textBoxUserName.Text;
            string password = this.textBoxPassword.Text;
            string r = websiteModel.Login(this.webBrowser1,loginUrl, username, password);
            MessageBox.Show(r);
        }
    }
}
