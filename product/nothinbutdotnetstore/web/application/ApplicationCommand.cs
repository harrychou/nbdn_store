using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public abstract class ApplicationCommand<Service>: ApplicationCommand {
        protected ResponseEngine response_engine;
        protected Service service;

        protected ApplicationCommand(ResponseEngine response_engine, Service service)
        {
            this.response_engine = response_engine;
            this.service = service;
        }
        
        public abstract void process(Request request);
    }
}