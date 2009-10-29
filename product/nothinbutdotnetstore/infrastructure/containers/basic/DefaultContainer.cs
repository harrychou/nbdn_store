using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultContainer : Container
    {
        private readonly ImplementationRegistry implementation_registry;
        private readonly InstanceActivator instance_activator;

        public DefaultContainer(ImplementationRegistry implementation_registry, InstanceActivator instance_activator)
        {
            this.implementation_registry = implementation_registry;
            this.instance_activator = instance_activator;
        }

        public Dependency instance_of<Dependency>()
        {
            return (Dependency)instance_of(typeof (Dependency));
        }

        public object instance_of(Type dependency_type)
        {
            return instance_activator.activate(implementation_registry.get_implementation_of(dependency_type));
        }

        public IEnumerable<DependencyType> all_instances_of<DependencyType>()
        {
            throw new NotImplementedException();
        }
    }
}