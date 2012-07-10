// Silverlight Vista Sidebar Gadget Template created by Ioan Lazarciuc
// http://www.lazarciuc.ro/ioan
// Contact form present on website
// Based on the Vista Sidebar Gadget Template created by Tim Heuer 
// http://timheuer.com/blog/

using System;
using System.Windows.Browser;

namespace SilverlightGadgetUtilities
{
    /// <summary>
    /// Utility class for interacting with the Gadget Sidebar API.
    /// </summary>
    public static class SilverlightGadget
    {
        /// <summary>
        /// Gets or sets settings for the gadget.
        /// </summary>
        public static GadgetSettingsCollection Settings
        {
            get { return GadgetSettingsCollection.Instance; }
        }

        /// <summary>
        /// Sets the URL for the HTML page used as flyout.
        /// <remarks>Write-only because getter throws exception</remarks>
        /// </summary>
        public static string FlyoutPage
        {
            //get
            //{
            //    return HtmlPage.Window.Eval("System.Gadget.Flyout.file") as string;
            //}
            set
            {
                HtmlPage.Window.Eval(String.Format("System.Gadget.Flyout.file=\"{0}\";", value));
            }
        }

        /// <summary>
        /// Gets or sets the URL for the HTML page used as a settings page.
        /// </summary>
        public static string SettingsUI
        {
            get
            {
                return HtmlPage.Window.Eval("System.Gadget.settingsUI") as string;
            }
            set
            {
                HtmlPage.Window.Eval(String.Format("System.Gadget.settingsUI=\"{0}\";", value));
            }
        }

        /// <summary>
        /// Gets or sets the URL for the image used as background for the gadget.
        /// </summary>
        public static string BackgroundImageUrl
        {
            get
            {
                return HtmlPage.Window.Eval("System.Gadget.background") as string;
            }
            set
            {
                HtmlPage.Window.Eval(String.Format("System.Gadget.background=\"{0}\";", value));
            }
        }

        /// <summary>
        /// Gets the docked state of the gadget.
        /// </summary>
        public static bool Docked
        {
            get
            {
                return Convert.ToBoolean(HtmlPage.Window.Eval("System.Gadget.docked"));
            }
        }

        /// <summary>
        /// Gets the name of the gadget.
        /// </summary>
        public static string Name
        {
            get
            {
                return Convert.ToString(HtmlPage.Window.Eval("System.Gadget.name"));
            }
        }

        /// <summary>
        /// Gets the opacity of the gadget.
        /// </summary>
        public static byte Opacity
        {
            get
            {
                return Convert.ToByte(HtmlPage.Window.Eval("System.Gadget.opacity"));
            }
        }

        /// <summary>
        /// Gets the UNC path where the gadget is installed.
        /// </summary>
        public static string Path
        {
            get
            {
                return Convert.ToString(HtmlPage.Window.Eval("System.Gadget.path"));
            }
        }

        /// <summary>
        /// Gets the version of the Sidebar API.
        /// </summary>
        public static string PlatformVersion
        {
            get
            {
                return Convert.ToString(HtmlPage.Window.Eval("System.Gadget.platformVersion"));
            }
        }

        /// <summary>
        /// Gets the version of the gadget.
        /// </summary>
        public static string Version
        {
            get
            {
                return Convert.ToString(HtmlPage.Window.Eval("System.Gadget.version"));
            }
        }

        /// <summary>
        /// Gets the visibility of the gadget.
        /// </summary>
        public static bool Visible
        {
            get
            {
                return Convert.ToBoolean(HtmlPage.Window.Eval("System.Gadget.visible"));
            }
        }

        /// <summary>
        /// Opens the flyout, with the currently specified page.
        /// </summary>
        public static void Flyout()
        {
            Flyout(true);
        }

        /// <summary>
        /// Opens or closes the flyout.
        /// </summary>
        /// <param name="show">true to open, false to close the flyout</param>
        public static void Flyout(bool show)
        {
            HtmlPage.Window.Eval(@"System.Gadget.Flyout.show = true;");
        }

        /// <summary>
        /// Set the size of the body tag of the page that hosts the gadget.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        public static void SetGadgetSize(int width, int height)
        {
            HtmlPage.Window.Eval(String.Format("var oBody = System.Gadget.document.body.style;oBody.width" +
                                               " = '{0}px';oBody.height = '{1}px';", width, height));
        }

        /// <summary>
        /// Set the size of the body tag of the page that hosts the gadget.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        /// <remarks>size values are converted to integers by rounding.</remarks>
        public static void SetGadgetSize(double width, double height)
        {
            SetGadgetSize(Convert.ToInt32(width), Convert.ToInt32(height));
        }

        /// <summary>
        /// Set the size of the body tag of the page.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        public static void SetPageSize(int width, int height)
        {
            HtmlPage.Window.Eval(String.Format("var oBody = document.body.style;oBody.width" +
                                               " = '{0}px';oBody.height = '{1}px';", width, height));
        }

        /// <summary>
        /// Set the size of the body tag of the page.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        /// <remarks>size values are converted to integers by rounding.</remarks>
        public static void SetPageSize(double width, double height)
        {
            SetPageSize(Convert.ToInt32(width), Convert.ToInt32(height));
        }

        /// <summary>
        /// Set the size of the body tag of the page that hosts the flyout.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        public static void SetFlyoutSize(int width, int height)
        {
            HtmlPage.Window.Eval(String.Format("var oBody = System.Gadget.Flyout.document.body.style;oBody.width" +
                                               " = '{0}px';oBody.height = '{1}px';", width, height));
        }

        /// <summary>
        /// Set the size of the body tag of the page that hosts the flyout.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        /// <remarks>size values are converted to integers by rounding.</remarks>
        public static void SetFlyoutSize(double width, double height)
        {
            SetFlyoutSize(Convert.ToInt32(width), Convert.ToInt32(height));
        }

        /// <summary>
        /// Closes the current instance of the gadget.
        /// </summary>
        public static void Close()
        {
            HtmlPage.Window.Eval("System.Gadget.close();");
        }
    }
}
