using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        private IEnumerable<Command> command_list;

        public DefaultCommandRegistry(IEnumerable<Command> command_list)
        {
            this.command_list = command_list;
        }

        public Command get_command_that_can_process(Request request)
        {
            foreach(var command in command_list )
            {
                if( command.can_handle( request ))
                {
                    return command;
                }
            }
            return new MissingCommand();
        }
    }
}