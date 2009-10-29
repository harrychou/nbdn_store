using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandChain {
        ConfigureCoreServices service_wrapper;
        IList<Command> commands = new List<Command>();

        public StartupCommandChain(ConfigureCoreServices start_command)
        {
            service_wrapper = start_command;
        }

        public StartupCommandChain followed_by<T>() where T : Command
        {
            var comamnd = (Command) Activator.CreateInstance(typeof(T), service_wrapper.Service);
            commands.Add(comamnd);

            return this;
        }

        public void finish_by<T>() where T : Command
        {
            var comamnd = (Command)Activator.CreateInstance(typeof(T), service_wrapper.Service);
            commands.Add(comamnd);

            run_all_commands();
        }

        void run_all_commands()
        {
            foreach (var command in commands)
            {
                command.run();
            }
        }
    }
}