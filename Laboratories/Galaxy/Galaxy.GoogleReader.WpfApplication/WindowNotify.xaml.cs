using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
    /// Interaction logic for WindowNotify.xaml
    /// </summary>
    public partial class WindowNotify : Window
    {
        private Timer m_Timer;

        public WindowNotify()
        {
            InitializeComponent();
            m_Timer = new Timer
                          {
                              Interval = 5 * 1000
                          };
            m_Timer.Elapsed += new ElapsedEventHandler(m_Timer_Elapsed);
            m_Timer.Start();
        }

        void m_Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            m_Timer.Stop();
            this.Close();
        }

        public List<Feed> UpdateItems { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (null != this.UpdateItems)
            {
                foreach (Feed feed in UpdateItems)
                {
                    var item = new ListBoxItem()
                                   {
                                       Content = feed.Title,
                                   };
                    this.listBox1.Items.Add(item);
                }
            }
        }
    }
}
