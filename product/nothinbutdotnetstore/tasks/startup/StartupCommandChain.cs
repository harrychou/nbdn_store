using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandChain
    {
        StartupCommandRunner runner;
        IList<Type> command_types = new List<Type>();


        public StartupCommandChain(StartupCommandRunner runner,Type initial_command_type)
        {
            this.runner = runner;
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
            runner.run(command_types);
        }

        void add_command_for<T>()
        {
            command_types.Add(typeof (T));
        }
    }
}