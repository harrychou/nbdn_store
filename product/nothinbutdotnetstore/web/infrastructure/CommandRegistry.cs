namespace nothinbutdotnetstore.web.infrastructure
{
    public interface CommandRegistry
    {
        Command get_command_that_can_process(Request request);
    }
}