using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandChain
    {
        StartupCommandFactory command_factory;
        Command chain;

        public StartupCommandChain(StartupCommandFactory command_factory, Type initial_command_type)
        {
            this.command_factory = command_factory;
            chain = command_factory.create_command_from(initial_command_type);
        }

        public StartupCommandChain followed_by<StartupStep>() where StartupStep : StartupCommand
        {
            add_command_for(typeof (StartupStep));
            return this;
        }

        public void finish_by<T>() where T : StartupCommand
        {
            followed_by<T>();
            chain.run();
        }

        void add_command_for(Type command_type)
        {
            chain = new CombinedCommand(chain, command_factory.create_command_from(command_type));
        }

    }
}