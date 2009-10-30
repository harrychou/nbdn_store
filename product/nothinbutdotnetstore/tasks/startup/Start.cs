using System;
using System.IO;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        static public StartupCommandChain by_running<T>() where T : StartupCommand
        {
            return create_initial_command_chain(typeof (T));
        }

        static public void by_running_all_commands_in(string pipeline_configuration_file)
        {
            var all_startup_command_types = File.ReadAllLines(pipeline_configuration_file).map_all(new StartupCommandTypeNameResolverer());
            create_initial_command_chain(typeof (NonStartupCommand)).run_all_commands_in(
                all_startup_command_types.map_all(new TypeMapper()));
        }

        static StartupCommandChain create_initial_command_chain(Type initial_command_type)
        {
            return new StartupCommandChain(new StartupCommandFactory(), initial_command_type);
        }

        class NonStartupCommand : StartupCommand
        {
            ContainerCoreService core_service;

            public NonStartupCommand(ContainerCoreService core_service)
            {
                this.core_service = core_service;
            }

            public void run() {}
        }
    }
}