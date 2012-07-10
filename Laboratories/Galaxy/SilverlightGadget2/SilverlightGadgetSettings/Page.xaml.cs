// Silverlight Vista Sidebar Gadget Template created by Ioan Lazarciuc
// http://www.lazarciuc.ro/ioan
// Contact form present on website
// Based on the Vista Sidebar Gadget Template created by Tim Heuer 
// http://timheuer.com/blog/

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;
using SilverlightGadgetUtilities;

namespace SilverlightGadgetSettings
{
    public partial class Page : UserControl
    {
        SilverlightGadgetEvents evHelper;
        public Page()
        {
            InitializeComponent();
            evHelper = new SilverlightGadgetEvents("SilverlightGadgetEvents");
            evHelper.SettingsClosing += new EventHandler<SettingsClosingEventArgs>(evHelper_SettingsClosing);
            evHelper.SettingsClosed += new EventHandler<SettingsClosingEventArgs>(evHelper_SettingsClosed);

            // Set gadget flyout size according to the one specified in the Silverlight control.
            SilverlightGadget.SetPageSize(Width, Height);
        }

        void evHelper_SettingsClosed(object sender, SettingsClosingEventArgs e)
        {
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // If through code the size of the Silverlight control is changed, change the size in the javascript gadget also.
            SilverlightGadget.SetPageSize(e.NewSize.Width, e.NewSize.Height);
        }

        void evHelper_SettingsClosing(object sender, SettingsClosingEventArgs e)
        {
            if (e.Action == CloseAction.Commit)
            {
                // Put code for saving settings here
                //SilverlightGadget.Settings["key"] = value;
            }
        }
    }
}
