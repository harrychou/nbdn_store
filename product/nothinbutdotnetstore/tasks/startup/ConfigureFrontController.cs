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
            core_services.register_an_activator_for<MapperRegistry>(() => new StubMapperRegistry());
            core_services.register_an_activator_for<FrontController>(() => new DefaultFrontController(core_services.resolve<CommandRegistry>()));
            core_services.register_an_activator_for<FrontControllerRequestFactory>(() => new StubRequestFactory());
        }
    }
}