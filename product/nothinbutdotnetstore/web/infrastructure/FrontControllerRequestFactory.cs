using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface FrontControllerRequestFactory
    {
        object create_from(HttpContext http_context);
    }
}