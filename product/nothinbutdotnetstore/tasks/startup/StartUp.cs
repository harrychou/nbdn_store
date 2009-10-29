using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartUp
    {
        static public void run()
        {
            ActivatorRegistry registry = new DefaultActivatorRegistry(new Dictionary<Type, InstanceActivator>());
            Container container = new DefaultContainer(registry);
            IOC.initialize_with(container);

            //do the rest
        }
    }
}