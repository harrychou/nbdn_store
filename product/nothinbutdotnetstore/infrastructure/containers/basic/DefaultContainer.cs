using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultContainer : Container
    {
        ActivatorRegistry activator_registry;

        public DefaultContainer(ActivatorRegistry activator_registry)
        {
            this.activator_registry = activator_registry;
        }

        public Dependency instance_of<Dependency>()
        {
            return (Dependency) instance_of(typeof (Dependency));
        }

        public object instance_of(Type dependency_type)
        {
            var activator = activator_registry.get_activator_for(dependency_type);
            
            try
            {
                return activator.create();
            }
            catch (Exception e)
            {
                throw new ActivatorCreationException(e,dependency_type);
            }
        }

        public IEnumerable<DependencyType> all_instances_of<DependencyType>()
        {
            throw new NotImplementedException();
        }
    }
}