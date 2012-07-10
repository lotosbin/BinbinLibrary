using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPlugin
{
    public interface IPlugin
    {
        Guid RuntimeKey { get; }
        bool AutoStart { get; set; }
        void Start();
        List<IPluginAction> Actions { get; }
        void Stop();
    }
}
