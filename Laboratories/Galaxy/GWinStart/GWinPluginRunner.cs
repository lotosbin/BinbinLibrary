using System;
using System.Windows.Forms;
using GContainer;
using GLog;
using GPlugin;

namespace GWinStart
{
    public static class GWinPluginRunner
    {
        public static void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void Run(PluginDefinition pluginDefinition)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 mainForm = new Form1();
            var container = Container.Instance;
            container.Register<IPluginHost, Form1>();
            IPluginHost host = container.GetInstance<IPluginHost>();
            var pluginType = pluginDefinition.PluginType;
            var instance = Activator.CreateInstance(pluginType);
            var autoStart = pluginDefinition.AutoStart;
            host.RuntimeInstall(instance as IPlugin, false);
            Application.Run(mainForm);

        }
    }
}