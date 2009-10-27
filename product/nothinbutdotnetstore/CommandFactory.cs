using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore
{
    public interface CommandFactory {
        void create_from(Request request);
    }
}