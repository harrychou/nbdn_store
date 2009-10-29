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
        Dictionary<Type, InstanceActivator> activator_list;

        public DefaultActivatorRegistry(Dictionary<Type, InstanceActivator> activator_list)
        {
            this.activator_list = activator_list;
        }

        public InstanceActivator get_activator_for(Type type)
        {
            if (activator_list.ContainsKey(type))
                return activator_list[type];
            return null;
        }
    }
}