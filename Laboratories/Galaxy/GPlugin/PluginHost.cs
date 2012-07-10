using System;
using System.Collections.Generic;

namespace GPlugin
{
    [Serializable]
    public class PluginHost : IPluginHost
    {
        #region Implementation of IPluginHost
        Dictionary<Guid, IPlugin> plugins = new Dictionary<Guid, IPlugin>();
        public void RuntimeInstall(IPlugin plugin, bool autoStart)
        {
            plugins.Add(plugin.RuntimeKey, plugin);
            if (autoStart)
            {
                plugin.Start();
            }
        }
        public void RuntimeUninstall(Guid plguinGuid)
        {
            var plugin = this.plugins[plguinGuid];
            plugin.Stop();
            plugins.Remove(plguinGuid);
        }

        public void Startup()
        {
            foreach (IPlugin plugin in plugins.Values)
            {
                
                plugin.Start();

            }
        }

        #endregion

        #region Implementation of IPlugin

        public Guid RuntimeKey { get; private set; }

        public bool AutoStart { get; set; }

        public void Start()
        {
             
        }

        private List<IPluginAction> m_Actions;

        public List<IPluginAction> Actions
        {
            get
            {
                if (null!=Actions)
                {
                     Actions=new List<IPluginAction>();
                }
                return this.m_Actions;
            }
            set { this.m_Actions = value; }
        }

        public void Stop()
        {
             
        }

        #endregion
    }
}