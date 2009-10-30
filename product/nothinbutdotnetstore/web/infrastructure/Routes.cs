using System;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class Routes
    {
        static public void add<AppCommand>(Predicate<Request> condition) where AppCommand : ApplicationCommand
        {
            IOC.resolve.instance_of<RouteTable>().register_route_for<AppCommand>(condition);
        }
    }
}