using System;

namespace GPlugin
{
    public class PluginDefinition
    {
        public PluginDefinition(Type pluginType, bool autoStart)
        {
            this.PluginType = pluginType;
            AutoStart = autoStart;
        }

        public Type PluginType { get; set; }

        public bool AutoStart { get; set; }
    }
}