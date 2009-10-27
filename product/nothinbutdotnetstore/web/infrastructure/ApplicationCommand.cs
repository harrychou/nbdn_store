namespace nothinbutdotnetstore.web.infrastructure
{
    public interface ApplicationCommand
    {
        void process(Request request);
    }
}