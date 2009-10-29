using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandChain
    {
        private readonly StartupCommandFactory command_factory;
        IList<Type> command_types = new List<Type>();


        public StartupCommandChain(StartupCommandFactory command_factory,Type initial_command_type)
        {
            this.command_factory = command_factory;
            command_types.Add(initial_command_type);
        }

        public StartupCommandChain followed_by<StartupStep>() where StartupStep : StartupCommand
        {
            add_command_for<StartupStep>();
            return this;
        }

        public void finish_by<T>() where T : StartupCommand
        {
            followed_by<T>();
            run_commands();
        }

        void add_command_for<T>()
        {
            command_types.Add(typeof (T));
        }

        public virtual void run_commands()
        {
            command_types.Select(type => command_factory.create_command_from(type))
                .each(command => command.run());
        }

    }
}