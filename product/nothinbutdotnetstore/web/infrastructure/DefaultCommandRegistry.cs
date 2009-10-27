using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        private IEnumerable<Command> _commandList;

        public DefaultCommandRegistry(IEnumerable<Command> commandList)
        {
            _commandList = commandList;
        }

        public Command get_command_that_can_process(Request request)
        {
            foreach(Command command in _commandList )
            {
                if( command.can_handle( request ))
                {
                    return command;
                }
            }
            return null;
        }
    }
}