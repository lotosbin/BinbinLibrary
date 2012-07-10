using System;
using System.Web;
using Microsoft.Practices.Unity;

namespace BinbinMvcUnityApplication
{
    /// <summary>
    /// 生命周期管理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpContextLifetimeManager<T> : LifetimeManager, IDisposable
    {
        public override object GetValue()
        {
            return HttpContext.Current.Items[typeof(T).AssemblyQualifiedName];
        }
        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(typeof(T).AssemblyQualifiedName);
        }
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[typeof(T).AssemblyQualifiedName]
                = newValue;
        }
        public void Dispose()
        {
            RemoveValue();
        }
    }
}