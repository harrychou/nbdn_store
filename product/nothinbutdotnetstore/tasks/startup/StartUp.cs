using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartUp
    {
        static IDictionary<Type, InstanceActivator> activators;

        static public void run()
        {
            initialize_container();
        }

        static void initialize_container()
        {
            activators = new Dictionary<Type, InstanceActivator>();
            var container = initialize_the_container();

            var service = new DefaultContainerCoreService(container, activators);

            new TaskRegistrationCommand(service).run();
            new ViewEngineRegistrationCommand(service).run();
            new ApplicationCommandRegistrationCommand(service).run();
            new FrontControllerRegistrationCommand(service).run();
        }

        private static Container initialize_the_container() {
            ActivatorRegistry registry = new DefaultActivatorRegistry(activators);
            Container container = new DefaultContainer(registry);
            IOC.initialize_with(container);
            return container;
        }
    }
}