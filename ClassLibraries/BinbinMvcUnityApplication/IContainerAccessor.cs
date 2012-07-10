using Microsoft.Practices.Unity;

namespace BinbinMvcUnityApplication
{
    public interface IContainerAccessor
    {
        IUnityContainer Container { get; }
    }
}