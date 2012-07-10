using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace BinbinMvcUnityApplication
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
