using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GalaxyAutoEntity.WpfApplication.Core;
using GalaxyAutoEntity.WpfApplication.Sample;

namespace GalaxyAutoEntity.WpfApplication
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
            AutoEntity user = new SampleEntities().User;
            foreach (AutoEntityProperty property in user.Properties.Values)
            {
                var element = new Label()
                                  {
                                      Content = property.PropertyName,
                                  };
                this.StackPanell1.Children.Add(element);
                var textBox = new TextBox
                                  {
                                      Tag = property,
                                      Text = property.ValueAsString,
                                  };
                this.StackPanell1.Children.Add(textBox);

            }
        }
    }
}
