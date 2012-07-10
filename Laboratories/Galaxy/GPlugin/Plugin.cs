using System;
using System.Collections.Generic;

namespace GPlugin
{
    public abstract class Plugin:PluginHost,IPlugin
    {
        public List<IPluginAction> Actions=new List<IPluginAction>();

        #region Implementation of IPlugin

        public abstract Guid RuntimeKey { get; }

        public   bool AutoStart { get; set; }

        public abstract void Start();

        public abstract void Stop();

        #endregion
    }
}