using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class FrontControllerComponents : ContainerRegistry
    {
        private readonly ContainerCoreService container_core_service;

        public FrontControllerComponents(ContainerCoreService container_core_service)
        {
            this.container_core_service = container_core_service;
        }

        public void Register()
        {
            container_core_service.register_an_activator_for<MapperRegistry>(() => new StubMapperRegistry());
            container_core_service.register_an_activator_for<FrontController>(() => new DefaultFrontController(container_core_service.resolve<CommandRegistry>()));
            container_core_service.register_an_activator_for<FrontControllerRequestFactory>(() => new StubRequestFactory());
        }
    }
}