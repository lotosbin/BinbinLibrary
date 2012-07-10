using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Galaxy.GoogleReader.Client;
using Galaxy.GoogleReader.WpfApplication.Engine;
using Galaxy.GoogleReader.WpfApplication.Models;

namespace Galaxy.GoogleReader.WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public GoogleReaderClient GetReader()
        {
            return this.m_GoogleReaderEngine.GoogleReaderClient;
        }

        private GoogleReaderEngine m_GoogleReaderEngine;
        private ClientEngine m_ClientEngine;

        public MainWindow()
        {
            InitializeComponent();
            this.m_GoogleReaderEngine = new GoogleReaderEngine();
            this.m_GoogleReaderEngine.Update += MGoogleReaderEngineOnUpdate;
            this.m_GoogleReaderEngine.Start();
            m_ClientEngine = new ClientEngine();
            m_ClientEngine.Update += new System.EventHandler<ClientEngineEventArgs>(m_ClientEngine_Update);
            this.m_ClientEngine.Start();
        }

        private void MGoogleReaderEngineOnUpdate(object sender, GoogleReaderEngineEventArgs e)
        {
            List<ListAllJsonItem> updateItems = e.UpdateItems;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new UpdateItemsDelegate(this.UpdateItems),
                                        updateItems);
        }
        public delegate void UpdateItemsDelegate(List<ListAllJsonItem> updateItems);
        private void UpdateItems(List<ListAllJsonItem> updateItems)
        {
            foreach (ListAllJsonItem visualYSnappingGuideline in updateItems)
            {
                var listBoxItem = new ListBoxItem()
                                      {
                                          Content = visualYSnappingGuideline.Title,
                                          Tag = visualYSnappingGuideline,
                                      };
                this.listBox1.Items.Add(listBoxItem);
            }
        }

        void m_ClientEngine_Update(object sender, ClientEngineEventArgs e)
        {
            foreach (Feed feed in e.UpdateItems)
            {
                var item = new ListBoxItem()
                               {
                                   Content = feed.Title
                               };

                this.listBoxLocalItems.Items.Add(item);
            }
            var windowNotify = new WindowNotify()
                                   {
                                       WindowStartupLocation = WindowStartupLocation.CenterScreen,

                                       ShowInTaskbar = false,
                                       Topmost = true,
                                       UpdateItems = e.UpdateItems,
                                   };
            windowNotify.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ListAllJson s = this.GetReader().ListAllJson();

            foreach (ListAllJsonItem item in s.Items)
            {
                var listBoxItem = new ListBoxItem();
                listBoxItem.Content = item.Title;
                listBoxItem.Tag = item;
                this.listBox1.Items.Add(listBoxItem);
            }
            var unreadCount = this.GetReader().GetUnreadCountJson();
            var listViewItem = new ListViewItem
                                   {
                                       Content = unreadCount.Max
                                   };
            this.listView1.Items.Add(listViewItem);
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBoxItem = e.AddedItems[0] as ListBoxItem;
            var item = listBoxItem.Tag as ListAllJsonItem;
            var summary = item.Summary;
            if (summary != null) this.textBox2.Text = summary.Content;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var windowUserInfo = new WindowUserInfo
                                     {
                                         UserInfo = this.GetReader().GetUserInfo()
                                     };
            windowUserInfo.DataBind();
            windowUserInfo.ShowDialog();
        }



        private void button5_Click(object sender, RoutedEventArgs e)
        {
            var tagsJson = this.GetReader().GetTagsJson();
            var windowTags = new WindowTags
                                 {
                                     Owner = this,
                                     Tags = tagsJson
                                 };
            windowTags.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var windowAddSubscribe = new WindowAddSubscribe
                                         {
                                             Owner = this
                                         };
            bool? showDialog = windowAddSubscribe.ShowDialog();
            if (showDialog.HasValue && showDialog.Value)
            {
                var subscribeUri = windowAddSubscribe.SubscribeUri;
                var addFeed = this.GetReader().AddFeed(subscribeUri.ToString());
                if (addFeed)
                {
                    MessageBox.Show("add subscribe success");
                }
                else
                {
                    MessageBox.Show("add subscribe failed");
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.m_GoogleReaderEngine.Stop();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
