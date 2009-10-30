using System.Collections.Generic;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureFrontController : StartupCommand
    {
        ContainerCoreService core_services;

        public ConfigureFrontController(ContainerCoreService core_services)
        {
            this.core_services = core_services;
        }

        public void run()
        {
            var default_route_table = new DefaultRouteTable();
            core_services.register_an_activator_for<RouteTable>(() => default_route_table);
            core_services.register_an_activator_for<IEnumerable<Command>>(() => default_route_table);
            core_services.register_an_activator_for<CommandRegistry>(() => new DefaultCommandRegistry(default_route_table));
            core_services.register_an_activator_for<MapperRegistry>(() => new StubMapperRegistry());
            core_services.register_an_activator_for<FrontController>(() => new DefaultFrontController(core_services.resolve<CommandRegistry>()));
            core_services.register_an_activator_for<FrontControllerRequestFactory>(() => new StubRequestFactory());
        }
    }
}