using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface ActivatorRegistry
    {
        InstanceActivator get_activator_for(Type type);
    }

    public class DefaultActivatorRegistry : ActivatorRegistry
    {
        IDictionary<Type, InstanceActivator> activator_list;

        public DefaultActivatorRegistry(IDictionary<Type, InstanceActivator> activator_list)
        {
            this.activator_list = activator_list;
        }

        public InstanceActivator get_activator_for(Type type)
        {
            if (!activator_list.ContainsKey(type)) throw new ActivatorNotFoundException(type);

            return activator_list[type];
        }
    }

    public class ActivatorNotFoundException : Exception
    {
        Type type;

        public ActivatorNotFoundException(Type type): base(type.FullName + " not found ")
        {
            this.type = type;
        }


    }
}