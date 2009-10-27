using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        readonly IEnumerable<Command> commands;

        public DefaultCommandRegistry(IEnumerable<Command> commands)
        {
            this.commands = commands;
        }

        public Command get_command_that_can_process(Request request)
        {
            foreach (var command in commands)
            {
                if (command.can_handle(request)) return command;
            }

            return new MissingCommand();
        }
    }
}