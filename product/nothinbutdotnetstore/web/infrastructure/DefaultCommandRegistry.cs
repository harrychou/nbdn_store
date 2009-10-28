using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<Command> command_list;

        public DefaultCommandRegistry(IEnumerable<Command> command_list)
        {
            this.command_list = command_list;
        }

        public Command get_command_that_can_process(Request request)
        {
            return command_list.FirstOrDefault(command => command.can_handle(request)) ?? new MissingCommand();
        }
    }
}