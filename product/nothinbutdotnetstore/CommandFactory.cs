using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore
{
    public interface CommandFactory {
        Command create_from(Request request);
    }
}