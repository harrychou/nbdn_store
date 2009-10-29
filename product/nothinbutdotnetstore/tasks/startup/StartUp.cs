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
            var container = initialize_the_container();

            register_service_tasks(container);
            register_view_engine_components(container);
            register_command_components(container);
            register_front_controller_components(container);
        }

        private static void register_front_controller_components(Container container) {
            register_an_activator_for<MapperRegistry>(() => new StubMapperRegistry());
            register_an_activator_for<FrontController>(() => new DefaultFrontController(container.instance_of<CommandRegistry>()));
            register_an_activator_for<FrontControllerRequestFactory>(() => new StubRequestFactory());
        }

        private static void register_command_components(Container container) {
            register_an_activator_for<ViewModelDisplay<IEnumerable<DepartmentItem>>>(
                () => new ViewModelDisplay<IEnumerable<DepartmentItem>>(container.instance_of<ResponseEngine>(), request => container.instance_of<CatalogTasks>().get_main_departments()));

            register_an_activator_for<CommandRegistry>(() => new DefaultCommandRegistry(all_commands()));
        }

        private static void register_view_engine_components(Container container) {
            register_an_activator_for<ViewPathRegistry>(() => new StubViewPathRegistry());
            register_an_activator_for<ViewFactory>(() => new DefaultViewFactory(container.instance_of<ViewPathRegistry>(),
                BuildManager.CreateInstanceFromVirtualPath));

            register_an_activator_for<ResponseEngine>(() => new DefaultResponseEngine(container.instance_of<ViewFactory>(),
                (handler, preserve_form) => HttpContext.Current.Server.Transfer(handler, preserve_form)));
        }

        private static void register_service_tasks(Container container)
        {
            register_an_activator_for<CatalogTasks>(() => new StubViewMainDepartmentTasks());
        }

        private static Container initialize_the_container() {
            ActivatorRegistry registry = new DefaultActivatorRegistry(activators);
            Container container = new DefaultContainer(registry);
            IOC.initialize_with(container);
            return container;
        }

        static IEnumerable<Command> all_commands()
        {
            yield return new DefaultCommand(request => true, IOC.resolve.instance_of<ViewModelDisplay<IEnumerable<DepartmentItem>>>()); 
        }

        static void register_an_activator_for<ContractType>(Func<object> activator)
        {
            activators.Add(typeof (ContractType), new FunctionalInstanceActivator(activator));
        }
    }
}