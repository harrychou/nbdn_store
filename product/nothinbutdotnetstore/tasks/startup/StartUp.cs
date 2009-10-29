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
            activators = new Dictionary<Type, InstanceActivator>();
            ActivatorRegistry registry = new DefaultActivatorRegistry(activators);
            Container container = new DefaultContainer(registry);
            IOC.initialize_with(container);

            registering_activator_for<CatalogTasks>(() => new StubViewMainDepartmentTasks());
            registering_activator_for<ViewPathRegistry>(() => new StubViewPathRegistry());
            registering_activator_for<ViewFactory>(() => new DefaultViewFactory(container.instance_of<ViewPathRegistry>(),
                                                                                BuildManager.CreateInstanceFromVirtualPath));

            registering_activator_for<MapperRegistry>(() => new StubMapperRegistry());
            registering_activator_for<ResponseEngine>(() => new DefaultResponseEngine(container.instance_of<ViewFactory>(),
                                                                                      (handler, preserve_form) => HttpContext.Current.Server.Transfer(handler, preserve_form)));

            registering_activator_for<ViewModelDisplay<IEnumerable<DepartmentItem>>>(
                () => new ViewModelDisplay<IEnumerable<DepartmentItem>>(container.instance_of<ResponseEngine>(), request => container.instance_of<CatalogTasks>().get_main_departments()));

            var commands = all_commands();

            registering_activator_for<CommandRegistry>(() => new DefaultCommandRegistry(commands));

            registering_activator_for<FrontController>(() => new DefaultFrontController(container.instance_of<CommandRegistry>()));
            registering_activator_for<FrontControllerRequestFactory>(() => new StubRequestFactory());
        }

        static IEnumerable<Command> all_commands()
        {
            yield return new DefaultCommand(request => true, IOC.resolve.instance_of<ViewModelDisplay<IEnumerable<DepartmentItem>>>()); 
        }

        static void registering_activator_for<ContractType>(Func<object> activator)
        {
            activators.Add(typeof (ContractType), new FunctionalInstanceActivator(activator));
        }
    }
}