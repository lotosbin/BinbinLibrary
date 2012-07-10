using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace WpfApplication2
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            // Let the user choose a TFS Server.
            this.textBox1.Text += ("Please enter a valid TFS Server or URI: ");
            String tfsServer = "http://tfs2.sinodn.cn/tfs/DefaultCollection";
            tfsServer = tfsServer.Trim();

            // Connect to the TeamFoundationServer.

            this.textBox1.Text += string.Format("Connecting to Team Foundation Server {0}...", tfsServer);
            TeamFoundationServer tfs =
                TeamFoundationServerFactory.GetServer(tfsServer);

            // Connect to the WorkItemStore.
            //this.textBox1.Text+=string.Format();
            this.textBox1.Text += string.Format("Reading from the Work Item Store...");
            WorkItemStore workItemStore = (WorkItemStore)tfs.GetService(typeof(WorkItemStore));

            // Display the details about the TeamFoundationServer.
            this.textBox1.Text += string.Format("\n");
            this.textBox1.Text += string.Format("Team Foundation Server details");
            this.textBox1.Text += string.Format("Server Name: " + tfs.Name);
            this.textBox1.Text += string.Format("Uri: " + tfs.Uri);
            this.textBox1.Text += string.Format("AuthenticatedUserDisplayName: " + tfs.AuthenticatedUserDisplayName);
            this.textBox1.Text += string.Format("AuthenticatedUserName: " + tfs.AuthenticatedUserName);
            this.textBox1.Text += string.Format("WorkItemStore:");

            //  List the Projects in the WorkItemStore.
            this.textBox1.Text += string.Format("  Projects.Count: " + workItemStore.Projects.Count);
            foreach (Project pr in workItemStore.Projects)
            {
                this.textBox1.Text += string.Format("    " + pr.Name);
            }
        }
    }
}
