using System.Collections.Generic;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureApplicationRoutes : StartupCommand
    {
        private readonly ContainerCoreService container_core_service;

        public ConfigureApplicationRoutes(ContainerCoreService container_core_service)
        {
            this.container_core_service = container_core_service;
        }

        public void run()
        {
            container_core_service.register_an_activator_for<ViewModelDisplay<IEnumerable<DepartmentItem>>>(
                () => new ViewModelDisplay<IEnumerable<DepartmentItem>>(container_core_service.resolve<ResponseEngine>(), request => container_core_service.resolve<CatalogTasks>().get_main_departments()));

           container_core_service.register_an_activator_for<CommandRegistry>(() => new DefaultCommandRegistry(all_commands()));
        }

        IEnumerable<Command> all_commands()
        {
            yield return new DefaultCommand(request => true, container_core_service.resolve<ViewModelDisplay<IEnumerable<DepartmentItem>>>()); 
        }
        
    }
}