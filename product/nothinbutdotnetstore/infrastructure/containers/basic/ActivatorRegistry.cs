using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface ActivatorRegistry {
        InstanceActivator get_activator_for(Type type);
    }
}