using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureApplicationCommands : StartupCommand
    {
        ContainerCoreService core_service;

        public ConfigureApplicationCommands(ContainerCoreService core_service)
        {
            this.core_service = core_service;
        }

        public void run()
        {
            core_service.register_an_activator_for<ViewMainDepartments>(() => new ViewMainDepartments(
                                                                                  core_service.resolve<ResponseEngine>(), core_service.resolve<CatalogTasks>()));
            core_service.register_an_activator_for<ViewSubDepartments>(() => new ViewMainDepartments(
                                                                                 core_service.resolve<ResponseEngine>(), core_service.resolve<CatalogTasks>()));
            core_service.register_an_activator_for<ViewDepartmentProducts>(() => new ViewMainDepartments(
                                                                                     core_service.resolve<ResponseEngine>(), core_service.resolve<CatalogTasks>()));
        }
    }
}