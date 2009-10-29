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
    public interface ContainerCoreService
    {
        void register_an_activator_for<ContractType>(Func<object> activator);
        Dependency resolve<Dependency>();
    }

    public class ConfigureServiceLayer: ContainerCommand
    {
        DefaultContainerCoreService service;
        public ConfigureServiceLayer(DefaultContainerCoreService service)
        {
            this.service = service;
        }

        public void run()
        {
            service.register_an_activator_for<CatalogTasks>(() => new StubViewMainDepartmentTasks());
        }
    }

    public class ConfigureViewEngine : ContainerCommand
    { 
        DefaultContainerCoreService service;
        public ConfigureViewEngine(DefaultContainerCoreService service)
        {
            this.service = service;
        }

        public void run()
        {
            service.register_an_activator_for<ViewPathRegistry>(() => new StubViewPathRegistry());
            service.register_an_activator_for<ViewFactory>(() => new DefaultViewFactory(
                    service.resolve<ViewPathRegistry>(),
                    BuildManager.CreateInstanceFromVirtualPath));

            service.register_an_activator_for<ResponseEngine>(() => new DefaultResponseEngine(
                    service.resolve<ViewFactory>(),
                    (handler, preserve_form) => HttpContext.Current.Server.Transfer(handler, preserve_form)));
        }
    }

    public class ConfigureApplicationRoutes : ContainerCommand
    {
        DefaultContainerCoreService service;
        public ConfigureApplicationRoutes(DefaultContainerCoreService service)
        {
            this.service = service;
        }

        public void run()
        {
            service.register_an_activator_for<ViewModelDisplay<IEnumerable<DepartmentItem>>>(
                      () => new ViewModelDisplay<IEnumerable<DepartmentItem>>(service.resolve<ResponseEngine>(), request => service.resolve<CatalogTasks>().get_main_departments()));

            service.register_an_activator_for<CommandRegistry>(() => new DefaultCommandRegistry(all_commands()));
     
        }

        IEnumerable<Command> all_commands()
        {
            yield return new DefaultCommand(request => true, IOC.resolve.instance_of<ViewModelDisplay<IEnumerable<DepartmentItem>>>());
        }
    }

    public class ConfigureFrontController : ContainerCommand
    { 
        DefaultContainerCoreService service;
        public ConfigureFrontController(DefaultContainerCoreService service)
        {
            this.service = service;
        }

        public void run() 
        {
            service.register_an_activator_for<MapperRegistry>(() => new StubMapperRegistry());
            service.register_an_activator_for<FrontController>(() => new DefaultFrontController(service.resolve<CommandRegistry>()));
            service.register_an_activator_for<FrontControllerRequestFactory>(() => new StubRequestFactory());
        }
    }

    public interface ContainerCommand 
    {
        void run();
    }


    public class DefaultContainerCoreService : ContainerCoreService {
        Container container;
        IDictionary<Type,InstanceActivator> activators;

        public DefaultContainerCoreService(Container container, IDictionary<Type, InstanceActivator> activators)
        {
            this.container = container;
            this.activators = activators;
        }

        public void register_an_activator_for<ContractType>(Func<object> activator)
        {
            activators.Add(typeof(ContractType), new FunctionalInstanceActivator(activator));
        }

        public Dependency resolve<Dependency>()
        {
            return container.instance_of<Dependency>();
        }
    }
}