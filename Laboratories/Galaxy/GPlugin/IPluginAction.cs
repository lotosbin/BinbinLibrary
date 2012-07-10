namespace GPlugin
{
    public interface IPluginAction
    {

        string ActionName { get; set; }

        void Execute();
    }
}