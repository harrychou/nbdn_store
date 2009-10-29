using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ServiceTasks : ContainerRegistry
    {
        private readonly ContainerCoreService container_core_service;

        public ServiceTasks(ContainerCoreService container_core_service)
        {
            this.container_core_service = container_core_service;
        }

        public void Register()
        {
            container_core_service.register_an_activator_for<CatalogTasks>(() => new StubViewMainDepartmentTasks());
        }
    }
}