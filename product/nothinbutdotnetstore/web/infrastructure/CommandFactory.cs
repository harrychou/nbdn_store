using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.tests.web
{
    public interface CommandFactory {
        void create_from(Request request);
    }
}