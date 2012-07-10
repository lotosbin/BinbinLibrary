using Microsoft.Practices.Unity;

namespace BinbinWebMvcUnity
{
    public static class UnityContainerInstance
    {
        private static IUnityContainer _instance;
        public static IUnityContainer Instance
        {
            get { return _instance ?? (_instance = new UnityContainer()); }

        }
    }
}