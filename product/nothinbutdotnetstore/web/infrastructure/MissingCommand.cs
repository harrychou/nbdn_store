using System;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class MissingCommand : Command
    {
        public void process(Request request)
        {
            throw new NotImplementedException("Need to come back and do something meaningful to describe what could not be processed");
        }

        public bool can_handle(Request request)
        {
            throw new NotImplementedException();
        }
    }
}