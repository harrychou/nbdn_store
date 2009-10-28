using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<Command> command_list;

        public DefaultCommandRegistry()
            : this(
                new List<Command>
                {
                    new DefaultCommand(
                        request => (request.action_name == DataKeys.view_sub_department_action),
                                       new ViewSubDepartments()),
                    new DefaultCommand(
                        request => (request.action_name == DataKeys.view_main_department_action),
                                       new ViewMainDepartments()),
                }
                ) {}

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