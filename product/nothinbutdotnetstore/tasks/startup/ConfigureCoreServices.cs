using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureCoreServices : StartupCommand
    {
        ContainerCoreService core_service;

        public ConfigureCoreServices(ContainerCoreService core_service)
        {
            this.core_service = core_service;
        }

        public void run()
        {
            IOC.initialize_with(core_service.container);
        }
    }
}