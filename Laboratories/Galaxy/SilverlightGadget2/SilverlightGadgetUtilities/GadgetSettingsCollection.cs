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
    /// Utility class that facilitates manipulation of Sidebar Gadget settings
    /// </summary>
    public class GadgetSettingsCollection
    {
        private static GadgetSettingsCollection inst;
        static GadgetSettingsCollection()
        {
            inst = new GadgetSettingsCollection();
        }

        /// <summary>
        /// Gets the singleton instance of the class
        /// </summary>
        public static GadgetSettingsCollection Instance
        {
            get
            {
                return inst;
            }
        }

        private GadgetSettingsCollection()
        {
        }

        /// <summary>
        /// Gets or sets a Sidebar Gadget setting
        /// </summary>
        /// <param name="key">the key for the setting</param>
        /// <returns>the current value of the setting</returns>
        public string this[string key]
        {
            get
            {
                return HtmlPage.Window.Eval(String.Format("System.Gadget.Settings.readString(\"{0}\")", key)) as string;
            }
            set
            {
                (HtmlPage.Window.Eval("System.Gadget.Settings") as ScriptObject).Invoke("writeString", key, value);
            }
        }
    }
}
