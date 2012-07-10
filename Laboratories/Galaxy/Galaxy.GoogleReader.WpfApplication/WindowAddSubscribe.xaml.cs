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

namespace Galaxy.GoogleReader.WpfApplication
{
    /// <summary>
    /// Interaction logic for WindowAddSubscribe.xaml
    /// </summary>
    public partial class WindowAddSubscribe : Window
    {
        public Uri SubscribeUri { get; set; }
        public WindowAddSubscribe()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.SubscribeUri = new Uri(this.textBox1.Text.Trim());
            this.DialogResult = true;
        }
    }
}
