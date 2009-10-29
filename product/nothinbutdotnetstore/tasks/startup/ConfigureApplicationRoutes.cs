using System.Collections.Generic;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureApplicationRoutes : StartupCommand
    {
        ContainerCoreService core_services;

        public ConfigureApplicationRoutes(ContainerCoreService core_services)
        {
            this.core_services = core_services;
        }

        public void run()
        {
            core_services.register_an_activator_for<ViewModelDisplay<IEnumerable<DepartmentItem>>>(
                () => new ViewModelDisplay<IEnumerable<DepartmentItem>>(core_services.resolve<ResponseEngine>(), request => core_services.resolve<CatalogTasks>().get_main_departments()));

           core_services.register_an_activator_for<CommandRegistry>(() => new DefaultCommandRegistry(all_commands()));
        }

        IEnumerable<Command> all_commands()
        {
            yield return new DefaultCommand(request => true, core_services.resolve<ViewModelDisplay<IEnumerable<DepartmentItem>>>()); 
        }
        
    }
}