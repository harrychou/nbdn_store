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
            var command = command_factory.create_from(request);
            command.process(request);
        }
    }
}