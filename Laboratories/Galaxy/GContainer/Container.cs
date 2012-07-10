using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GPlugin;

namespace GContainer
{
    public class Container 
    {
        private Container()
        {

        }
        private static Container m_Instance;

        public static Container Instance
        {
            get
            {
                if (null == m_Instance)
                {
                    m_Instance = new Container();
                }
                return m_Instance;
            }
        }


        Dictionary<Type, Type> maps = new Dictionary<Type, Type>();
        Dictionary<Type, object> instances = new Dictionary<Type, object>();
        public void Register<TInterface, TImplement>() where TImplement : TInterface
        {
            var key = typeof(TInterface);
            var value = typeof(TImplement);
            if (maps.ContainsKey(key))
            {
                maps[key] = value;
            }
            else
            {
                maps.Add(key, value);
            }
        }
        public void Register<TInterface, TImplement>(TInterface instance) where TImplement : TInterface
        {
            var key = typeof(TInterface);
            var value = typeof(TImplement);
            if (maps.ContainsKey(key))
            {
                maps[key] = value;
            }
            else
            {
                maps.Add(key, value);
            }

        }

        private void Register<TInterface>(TInterface instance)
        {
            var key = typeof(TInterface);
            var value = instance;
            if (maps.ContainsKey(key))
            {
                instances[key] = value;
            }
            else
            {
                instances.Add(key, value);
            }

        }
        public Type GetImplementType<TInterface>()
        {
            var key = typeof(TInterface);
            if (maps.ContainsKey(key))
            {
                return maps[key];
            }
            return null;
        }
        public TInterface CreateInstance<TInterface>()
        {
            var implementType = GetImplementType<TInterface>();
            if (implementType == null)
            {
                return default(TInterface);
            }
            try
            {
                var instance = Activator.CreateInstance(implementType);
                return null != instance && instance is TInterface ? (TInterface)instance : default(TInterface);
            }
            catch (Exception ex)
            {
                return default(TInterface);
            }
        }
        public TInterface GetInstance<TInterface>()
        {
            var key = typeof(TInterface);
            var implementType = GetImplementType<TInterface>();
            if (this.instances.ContainsKey(key))
            {
                {
                    var instance = this.instances[key];
                    if (instance.GetType().Equals(implementType))
                    {
                        return (TInterface)instance;
                    }
                }
                {
                    TInterface instance = CreateInstance<TInterface>();
                    if (null != instance)
                    {
                        this.instances.Add(key, instance);
                        return instance;
                    }

                }
            }
            else
            {
                TInterface instance = CreateInstance<TInterface>();
                if (null != instance)
                {
                    this.instances.Add(key, instance);
                    return instance;
                }
            }
            return default(TInterface);
        }
    }
}
