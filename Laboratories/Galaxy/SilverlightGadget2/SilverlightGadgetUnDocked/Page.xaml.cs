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

namespace SilverlightGadgetUnDocked
{
    public partial class Page : UserControl
    {
        SilverlightGadgetEvents evHelper;

        // Used to hide the Silverlight control from JavaScript when docking/undocking
        [ScriptableMember]
        public bool IsVisible
        {
            get { return this.Visibility == System.Windows.Visibility.Visible; }
            set { this.Visibility = value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed; }
        }

        public Page()
        {
            InitializeComponent();
            evHelper = new SilverlightGadgetEvents("SilverlightGadgetEventsU");
            evHelper.VisibilityChanged += new EventHandler(evHelper_VisibilityChanged);
            evHelper.SettingsClosed += new EventHandler<SettingsClosingEventArgs>(evHelper_SettingsClosed);
            evHelper.SettingsClosing += new EventHandler<SettingsClosingEventArgs>(evHelper_SettingsClosing);
            evHelper.ShowSettings += new EventHandler(evHelper_ShowSettings);
            evHelper.Undock += new EventHandler(evHelper_Undock);

            // Set gadget flyout size according to the one specified in the Silverlight control.
            if (!SilverlightGadget.Docked)
                SilverlightGadget.SetGadgetSize(Width, Height);
            HtmlPage.RegisterScriptableObject("undockedGadget", this);
        }

        void evHelper_Undock(object sender, EventArgs e)
        {
            SilverlightGadget.SetGadgetSize(Width, Height);
        }

        void evHelper_ShowSettings(object sender, EventArgs e)
        {
        }

        void evHelper_SettingsClosing(object sender, SettingsClosingEventArgs e)
        {
        }

        void evHelper_SettingsClosed(object sender, SettingsClosingEventArgs e)
        {
        }

        void evHelper_VisibilityChanged(object sender, EventArgs e)
        {
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // If through code the size of the Silverlight control is changed, change the size in the javascript gadget also.
            if (!SilverlightGadget.Docked)
                SilverlightGadget.SetGadgetSize(e.NewSize.Width, e.NewSize.Height);
        }
    }
}
