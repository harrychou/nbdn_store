using System;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandFactory
    {
        ContainerCoreService core_service;

        public StartupCommandFactory():this(new DefaultContainerCoreService())
        {
        }

        public StartupCommandFactory(ContainerCoreService core_service)
        {
            this.core_service = core_service;
        }

        public virtual Command create_command_from(Type type)
        {
            return (Command) Activator.CreateInstance(type, core_service);
        }
    }
}