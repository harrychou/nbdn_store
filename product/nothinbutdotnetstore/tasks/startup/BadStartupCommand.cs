using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public class BadStartupCommand : StartupCommand
    {
        ContainerCoreService container_core_service;
        public BadStartupCommand(ContainerCoreService container_core_service)
        {
            this.container_core_service = container_core_service;
        }

        public void run()
        {
            throw new NotImplementedException();
        }
    }
}