using System.Web;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class RequestHandler : IHttpHandler
    {
        FrontControllerRequestFactory request_factory;
        FrontController front_controller;

        public RequestHandler():this(IOC.resolve.instance_of<FrontControllerRequestFactory>(), 
           IOC.resolve.instance_of<FrontController>()) {}

        public RequestHandler(FrontControllerRequestFactory request_factory, FrontController frontController)
        {
            this.request_factory = request_factory;
            front_controller = frontController;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}