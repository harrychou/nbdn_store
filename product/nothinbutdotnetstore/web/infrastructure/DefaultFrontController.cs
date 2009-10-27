namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultFrontController : FrontController
    {
        CommandFactory command_factory;

        public DefaultFrontController(CommandFactory command_factory)
        {
            this.command_factory = command_factory;
        }

        public void process(Request request)
        {
            command_factory.create_from(request);
        }
    }
}