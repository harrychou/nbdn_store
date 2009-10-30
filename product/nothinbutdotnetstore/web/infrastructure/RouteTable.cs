using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface RouteTable : IEnumerable<Command>
    {
        void register_route_for<AppCommand>(Predicate<Request> condition) where AppCommand : ApplicationCommand;
    }

    public class DefaultRouteTable : List<Command>, RouteTable
    {
        public void register_route_for<AppCommand>(Predicate<Request> condition) where AppCommand : ApplicationCommand
        {
            Add(new DefaultCommand(condition, IOC.resolve.instance_of<AppCommand>()));
        }
    }
}