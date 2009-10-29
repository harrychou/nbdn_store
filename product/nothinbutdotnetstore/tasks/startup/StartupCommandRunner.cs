using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandRunner
    {
        StartupCommandFactory command_factory;

        public StartupCommandRunner():this(new StartupCommandFactory()) {}

        public StartupCommandRunner(StartupCommandFactory command_factory)
        {
            this.command_factory = command_factory;
        }

        public virtual void run(IEnumerable<Type> command_types)
        {
            command_types.Select(type => command_factory.create_command_from(type))
                .each(command => command.run());
        }
    }

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