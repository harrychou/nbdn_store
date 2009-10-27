namespace nothinbutdotnetstore.web.infrastructure
{
    public interface Command
    {
        object process(Request request);
        bool can_handle(Request request);
    }
}