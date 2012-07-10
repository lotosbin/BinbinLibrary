using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GContainer;
using GLog;
using GPlugin;
using GWinStart;

namespace GWinEntityGallery
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GWinPluginRunner.Run(new PluginDefinition(typeof(LogPlugin),true));
        }
    }
}
