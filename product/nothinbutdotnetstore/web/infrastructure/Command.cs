namespace nothinbutdotnetstore.web.infrastructure
{
    public interface Command
    {
        void process(Request request);
        bool can_handle(Request request);
    }
}