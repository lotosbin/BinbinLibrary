using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GPlugin;

namespace GWinEntityGallery
{
    [System.Runtime.InteropServices.GuidAttribute("6742C852-01AE-465A-8856-F7C9CAAAD7BB")]
    [Serializable]
    public class LogPlugin : Plugin
    {
        private Guid m_RuntimeKey;

        #region Implementation of IPlugin

        public override Guid RuntimeKey
        {
            get
            {
                if (Guid.Empty == m_RuntimeKey)
                {
                    this.m_RuntimeKey = Guid.NewGuid();
                }
                return this.m_RuntimeKey;
            }
        }

 
        public override void Start()
        {
            IPluginAction a = new PluginAction(Guid.NewGuid(), "ShowLogList");
            Actions.Add(a);
            MessageBox.Show("Start");
        }

        public override void Stop()
        {
            MessageBox.Show("stop");
        }

        #endregion
    }
}
