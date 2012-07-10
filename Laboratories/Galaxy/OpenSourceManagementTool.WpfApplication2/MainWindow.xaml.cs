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

namespace OpenSourceManagementTool.WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var siteRepository = new OpenSourceSiteRepository();
            foreach (var site in siteRepository.Sites)
            {
                var item = new ListBoxItem { Content = site.Name, Tag = site };
                this.listBox1.Items.Add(item);
            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selectedItem = this.listBox1.SelectedItem;
            if (null != selectedItem)
            {
                var listBoxItem = selectedItem as ListBoxItem;
                if (null != listBoxItem)
                {
                    var site = listBoxItem.Tag as OpenSourceSite;
                    if (null != site)
                    {
                        this.listBox2.Items.Clear();
                        foreach (var project in site.Projects)
                        {
                            var item = new ListBoxItem { Content = project.Name };
                            item.Tag = item;
                            this.listBox2.Items.Add(item);
                        }
                    }
                }
            }
        }
    }
}
