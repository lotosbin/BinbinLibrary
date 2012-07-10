using System;

namespace GPlugin
{
    public interface IPluginHost:IPlugin
    {
        void RuntimeInstall(IPlugin plugin,bool autoStart);

        void RuntimeUninstall(Guid plguinGuid);

    }
}