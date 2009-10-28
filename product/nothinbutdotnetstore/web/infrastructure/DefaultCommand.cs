using System;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultCommand : Command
    {
        Predicate<Request> criteria;
        ApplicationCommand application_command;

        public DefaultCommand(Predicate<Request> criteria,ApplicationCommand command)
        {
            this.criteria = criteria;
            this.application_command = command;

        }

        public void process(Request request) 
        {
            application_command.process(request);
        }

        public bool can_handle(Request request)
        {
            return criteria(request);
        }
    }
}