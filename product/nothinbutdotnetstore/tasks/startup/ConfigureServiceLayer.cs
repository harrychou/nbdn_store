using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureServiceLayer : StartupCommand
    {
        ContainerCoreService core_services;

        public ConfigureServiceLayer(ContainerCoreService core_services)
        {
            this.core_services = core_services;
        }

        public void run()
        {
            core_services.register_an_activator_for<CatalogTasks>(() => new StubViewMainDepartmentTasks());
        }
    }
}