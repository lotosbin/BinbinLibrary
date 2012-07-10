using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace BinbinWebMvcUnity
{
    public class UnityActionFilterProvider<TActionFilter> : IFilterProvider
            where TActionFilter : ActionFilterAttribute, new()
    {
        private IUnityContainer UnityContainer { get; set; }

        public UnityActionFilterProvider(IUnityContainer container)
        {
            this.UnityContainer = container;
        }

        private IList<ControllerAction> actions = new List<ControllerAction>();

        public void Add(string controllername, string actionname)
        {
            this.actions.Add(new ControllerAction() { ControllerName = controllername, ActionName = actionname });
        }

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            foreach (ControllerAction action in this.actions)
                if ((action.ControllerName == actionDescriptor.ControllerDescriptor.ControllerName || action.ControllerName == "*")
                    && (action.ActionName == actionDescriptor.ActionName || action.ActionName == "*"))
                {
                    yield return new Filter(this.UnityContainer.Resolve<TActionFilter>(), FilterScope.First, null);
                    break;
                }

            yield break;
        }
    }
}