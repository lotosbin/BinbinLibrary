using System;

namespace GPlugin
{
    public class PluginAction:IPluginAction
    {
        public Guid ActionGuid { get; set; }

        public string ActionName { get; set; }

        public PluginAction(Guid actionGuid,string actionName)
        {
            ActionGuid = actionGuid;
            ActionName = actionName;
        }

        private event EventHandler ActionExecute;

        private void InvokeActionExecute(EventArgs e)
        {
            EventHandler handler = this.ActionExecute;
            if (handler != null)
            {
                handler(this, e);
            }
        }
 

        public void Execute()
        {
            InvokeActionExecute(EventArgs.Empty);
        }
    }
}