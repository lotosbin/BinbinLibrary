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
using System.Windows.Shapes;
using Galaxy.GoogleReader.Client.Models.Tag;

namespace Galaxy.GoogleReader.WpfApplication
{
    /// <summary>
    /// Interaction logic for WindowTags.xaml
    /// </summary>
    public partial class WindowTags : Window
    {
        public WindowTags()
        {
            InitializeComponent();
        }

        public TagsJson Tags { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (null != this.Tags)
            {
                foreach (var tag in this.Tags.Tags)
                {
                    var listBoxItem = new ListBoxItem();
                    listBoxItem.Content = tag.Id;
                    this.listBox1.Items.Add(listBoxItem);
                }
            }
        }
    }
}
