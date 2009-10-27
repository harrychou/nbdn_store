using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        readonly IEnumerable<Command> _commands;

        public DefaultCommandRegistry(IEnumerable<Command> commands)
        {
            _commands = commands;
        }

        public Command get_command_that_can_process(Request request)
        {
            foreach (var command in _commands) 
            {
                if (command.can_handle(request)) return command;
            }

            return null;
        }
    }
}