using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartUp
    {
        static public void run()
        {
            var dictActivators = new Dictionary<Type, InstanceActivator>();
            ActivatorRegistry registy = new DefaultActivatorRegistry(dictActivators);
            IOC.initialize_with(new DefaultContainer(registy));

            TransferBehaviour transfer_bahavior = (handler, form) => HttpContext.Current.Server.Transfer(handler, form);

            ViewPathRegistry view_path_regitry = new StubViewPathRegistry();

            PageFactory page_factory = (path, type) => BuildManager.CreateInstanceFromVirtualPath(path, type);

            ViewFactory view_factory = new DefaultViewFactory(view_path_regitry, page_factory); ;

            ResponseEngine response_engine = new DefaultResponseEngine(view_factory, transfer_bahavior); ;

            CatalogTasks catalog_tasks = new StubViewMainDepartmentTasks();



            var view_main_department_command = new ViewMainDepartments(response_engine, catalog_tasks);


            Predicate<Request> view_main_department_command_predicate = request => true;

            var default_view_main_department_command = new DefaultCommand(view_main_department_command_predicate, view_main_department_command);
            var default_view_sub_department_command = new DefaultCommand(request => true, new ViewMainDepartments(response_engine, catalog_tasks));
            var default_view_department_product = new DefaultCommand(request => true, new ViewDepartmentProducts(response_engine, catalog_tasks));

            var shopping_card_tasks = new StubShoppingCartTask();
            var default_add_products = new DefaultCommand(request => true, new AddToCart(response_engine, shopping_card_tasks));

            IList<Command> commands = new List<Command>();
            commands.Add(default_view_main_department_command);
            commands.Add(default_view_sub_department_command);
            commands.Add(default_view_department_product);
            commands.Add(default_add_products);

            var command_registry = new DefaultCommandRegistry(commands);
          
            FrontController front_controller = new DefaultFrontController(command_registry);


            dictActivators.Add(typeof(FrontController), new FunctionalInstanceActivator(() => front_controller));
            dictActivators.Add(typeof(TransferBehaviour), new FunctionalInstanceActivator(() => transfer_bahavior));
            dictActivators.Add(typeof(CommandRegistry), new FunctionalInstanceActivator(() => command_registry));
            dictActivators.Add(typeof(ViewFactory), new FunctionalInstanceActivator(() => view_factory));
            dictActivators.Add(typeof(ResponseEngine), new FunctionalInstanceActivator(() => response_engine));
            var front_controller_request_factory = new StubRequestFactory();
            dictActivators.Add(typeof(FrontControllerRequestFactory), new FunctionalInstanceActivator(() => front_controller_request_factory));

            
        }
    }
}