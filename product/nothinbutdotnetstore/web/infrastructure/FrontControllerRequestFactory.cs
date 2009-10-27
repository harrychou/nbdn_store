using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface FrontControllerRequestFactory
    {
        Request create_from(HttpContext http_context);
    }
}