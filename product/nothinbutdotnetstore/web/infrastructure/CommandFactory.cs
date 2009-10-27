namespace nothinbutdotnetstore.web.infrastructure
{
    public interface CommandFactory {
        Command create_from(Request request);
    }
}