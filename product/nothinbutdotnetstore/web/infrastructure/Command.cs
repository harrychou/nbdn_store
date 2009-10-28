namespace nothinbutdotnetstore.web.infrastructure
{
    public interface Command : ApplicationCommand
    {

        bool can_handle(Request request);
    }
}