using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureServiceLayer : StartupCommand
    {
        ContainerCoreService container_core_service;

        public ConfigureServiceLayer(ContainerCoreService container_core_service)
        {
            this.container_core_service = container_core_service;
        }

        public void run()
        {
            container_core_service.register_an_activator_for<CatalogTasks>(() => new StubViewMainDepartmentTasks());
        }
    }
}