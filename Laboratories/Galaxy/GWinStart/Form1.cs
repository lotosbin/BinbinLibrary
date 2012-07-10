using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GPlugin;

namespace GWinStart
{
    public partial class Form1 : Form,IPlugin,IPluginHost
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            var container = GContainer.Container.Instance;
            IPluginHost pluginHost = container.GetInstance<IPluginHost>();
            pluginHost.Start();
        }

        #region Implementation of IPlugin

        public Guid RuntimeKey { get; private set; }

        public bool AutoStart { get; set; }

 

        public void Stop()
        {
            foreach (IPlugin plugin in plugins.Values)
            {
                plugin.Stop();
            }
        }

        #endregion

        #region Implementation of IPluginHost

        public void RuntimeInstall(IPlugin plugin, bool autoStart)
        {
            this.plugins.Add(plugin.RuntimeKey,plugin);
        }

        public void RuntimeUninstall(Guid plguinGuid)
        {
            this.plugins.Remove(plguinGuid);
        }
        Dictionary<Guid,IPlugin> plugins = new Dictionary<Guid, IPlugin>();
        public void Start()
        {
            foreach (IPlugin plugin in plugins.Values)
            {
                plugin.Start();
            }
            foreach (IPlugin plugin in plugins.Values)
            {
                foreach (IPluginAction action in plugin.Actions)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem(action.ActionName);
                    menuItem.Tag = action;
                    menuItem.Click += new EventHandler(menuItem_Click);
                    this.toolStripMenuItem1.DropDownItems.Add(menuItem);
                }
            }
        }

        public List<IPluginAction> Actions
        {
            get { throw new NotImplementedException(); }
        }

        void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            IPluginAction pluginAction = menuItem.Tag as IPluginAction;
            pluginAction.Execute();
        }

        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var container = GContainer.Container.Instance;
            IPluginHost pluginHost = container.GetInstance<IPluginHost>();
            pluginHost.Stop();

        }
    }
}
