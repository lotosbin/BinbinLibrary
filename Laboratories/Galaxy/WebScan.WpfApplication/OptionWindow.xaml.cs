using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WebScan.WpfApplication
{
    /// <summary>
    /// Interaction logic for OptionWindow.xaml
    /// </summary>
    public partial class OptionWindow : Window
    {
        public OptionWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string serverName = this.textBox1.Text.Trim();
            var userName = textBox2.Text.Trim();
            var passWord = textBox3.Text.Trim();
            var databaseName = textBox4.Text.Trim();
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = serverName;
            builder.UserID = userName;
            builder.Password = passWord;
            builder.InitialCatalog = databaseName;
            var connectionString = builder.ToString();

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = configuration.ConnectionStrings;

            const string connectionStringName = "GalaxyWebScan";
            var connectionStringSettings = connectionStringsSection.ConnectionStrings[connectionStringName];
            if (null != connectionStringSettings)
            {
                connectionStringsSection.ConnectionStrings.Remove(connectionStringName);
            }
            var stringSettings = new ConnectionStringSettings
                                     {
                                         Name = connectionStringName,
                                         ConnectionString = connectionString,
                                         ProviderName = "System.Data.SqlClient"
                                     };
            connectionStringsSection.ConnectionStrings.Add(stringSettings);
            configuration.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节   
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const string connectionStringName = "GalaxyWebScan";
            var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (null != connectionStringSettings)
            {
                var connectionString = connectionStringSettings.ConnectionString;
                var builder = new SqlConnectionStringBuilder(connectionString);
                this.textBox1.Text = builder.DataSource;
                this.textBox2.Text = builder.UserID;
                this.textBox3.Text = builder.Password;
                this.textBox4.Text = builder.InitialCatalog;
            }
        }
    }
}
