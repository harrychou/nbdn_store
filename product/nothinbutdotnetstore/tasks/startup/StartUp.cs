using System;
using System.Collections;
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
      static Dictionary<Type, InstanceActivator> activators;

        static public void run()
        {
          activators = new Dictionary<Type, InstanceActivator>();
          ActivatorRegistry registry = new DefaultActivatorRegistry(activators);
            Container container = new DefaultContainer(registry);
            IOC.initialize_with(container);

            //do the rest
          create_activator_for<CatalogTasks>(() => new StubViewMainDepartmentTasks());
          create_activator_for<ViewPathRegistry>(() => new StubViewPathRegistry());
          create_activator_for<ViewFactory>(() => new DefaultViewFactory(container.instance_of<ViewPathRegistry>(),
                                                                           BuildManager.CreateInstanceFromVirtualPath));

          create_activator_for<MapperRegistry>(() => new StubMapperRegistry());
          create_activator_for<Request>(() => new DefaultRequest(container.instance_of<MapperRegistry>()));

          create_activator_for<ResponseEngine>(()=> new DefaultResponseEngine(container.instance_of<ViewFactory>(),
            (handler, preserve_form) => HttpContext.Current.Server.Transfer(handler, preserve_form)));

          create_activator_for<ViewModelDisplay<IEnumerable<DepartmentItem>>>(
            () => new ViewModelDisplay<IEnumerable<DepartmentItem>>(container.instance_of<ResponseEngine>(), request => container.instance_of<CatalogTasks>().get_main_departments()));

          var commands = new List<Command>
           {
             new DefaultCommand(request => true, container.instance_of<ViewModelDisplay<IEnumerable<DepartmentItem>>>())
           };

          create_activator_for<CommandRegistry>(() => new DefaultCommandRegistry(commands));

          create_activator_for<FrontController>(() => new DefaultFrontController(container.instance_of<CommandRegistry>()));
          create_activator_for<FrontControllerRequestFactory>(() => new StubRequestFactory());

        }

        static private void create_activator_for<ContractType>(Func<object> activator) {
          activators.Add(typeof(ContractType), new FunctionalInstanceActivator(activator));
        }
    }
}