using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubRequestFactory : FrontControllerRequestFactory
    {
        public Request create_from(HttpContext http_context)
        {
            return new DefaultRequest(null);
        }

       
    }
}