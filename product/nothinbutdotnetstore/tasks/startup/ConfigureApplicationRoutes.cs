using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureApplicationRoutes : StartupCommand
    {
        public ConfigureApplicationRoutes(ContainerCoreService core_services)
        {
        }

        public void run()
        {
            Routes.add<ViewMainDepartments>(request => true);
        }
    }
}