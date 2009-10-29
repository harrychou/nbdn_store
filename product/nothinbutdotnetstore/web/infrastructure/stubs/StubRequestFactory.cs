using System.Web;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubRequestFactory : FrontControllerRequestFactory
    {
        public Request create_from(HttpContext http_context)
        {
            return new DefaultRequest(IOC.resolve.instance_of<MapperRegistry>());
        }

       
    }
}