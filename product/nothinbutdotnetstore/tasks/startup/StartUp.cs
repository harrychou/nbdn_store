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
        static public void run()
        {
            var activator_list = new Dictionary<Type, InstanceActivator>();

            activator_list.Add(typeof(ViewPathRegistry), new FunctionalInstanceActivator(() => new StubViewPathRegistry()));
            activator_list.Add(typeof(CatalogTasks), new FunctionalInstanceActivator(() => new StubViewMainDepartmentTasks()));
            activator_list.Add(typeof(MapperRegistry), new FunctionalInstanceActivator(() => new StubMapperRegistry()));


            activator_list.Add(typeof(Request), new FunctionalInstanceActivator(() => 
                new DefaultRequest((StubMapperRegistry)activator_list[typeof(StubMapperRegistry)].create())));
 
            TransferBehaviour transfer_behavior = HttpContext.Current.Server.Transfer;
            PageFactory page_factory = BuildManager.CreateInstanceFromVirtualPath;
            activator_list.Add(typeof(TransferBehaviour), new FunctionalInstanceActivator(() => transfer_behavior));
            activator_list.Add(typeof(PageFactory), new FunctionalInstanceActivator(() => page_factory));


            activator_list.Add(typeof (ViewFactory), new FunctionalInstanceActivator(() => 
                new DefaultViewFactory((ViewPathRegistry)activator_list[typeof(ViewPathRegistry)].create(), 
                    (PageFactory)activator_list[typeof(PageFactory)].create())));
            
            activator_list.Add(typeof(ResponseEngine), new FunctionalInstanceActivator(() => 
                new DefaultResponseEngine((ViewFactory)activator_list[typeof(ViewFactory)].create(), transfer_behavior)));


            activator_list.Add(typeof(ViewForModel<DepartmentItem>), new FunctionalInstanceActivator(() => new DefaultViewForModel<DepartmentItem>()));
            activator_list.Add(typeof(ViewForModel<ProductItem>), new FunctionalInstanceActivator(() => new DefaultViewForModel<ProductItem>()));
            activator_list.Add(typeof(ViewForModel<LineItem>), new FunctionalInstanceActivator(() => new DefaultViewForModel<LineItem>()));
            activator_list.Add(typeof(ViewForModel<CartItem>), new FunctionalInstanceActivator(() => new DefaultViewForModel<CartItem>()));


            IList<Command> command_list = new List<Command>();

            activator_list.Add(typeof(ViewModelDisplay<DepartmentItem>), new FunctionalInstanceActivator(() =>
            {
                return new ViewModelDisplay<IEnumerable<DepartmentItem>>(
                    (ResponseEngine) activator_list[typeof (ResponseEngine)].create(), r =>
                    {
                        return ((CatalogTasks) activator_list[typeof (CatalogTasks)].create()).get_main_departments();
                    });
            }));

            activator_list.Add(typeof(ViewModelDisplay<ProductItem>), new FunctionalInstanceActivator(() =>
            {
                return new ViewModelDisplay<IEnumerable<ProductItem>>(
                    (ResponseEngine) activator_list[typeof (ResponseEngine)].create(), r =>
                    {
                        return ((CatalogTasks) activator_list[typeof (CatalogTasks)].create()).get_all_products_in((DepartmentItem) activator_list[typeof (DepartmentItem)].create());
                    });
            }));


            activator_list.Add(typeof(CommandRegistry), new FunctionalInstanceActivator(() => new DefaultCommandRegistry(command_list)));



            

            

            ActivatorRegistry registry = new DefaultActivatorRegistry(activator_list);

            Container container = new DefaultContainer(registry);
            IOC.initialize_with(container);
    }
}