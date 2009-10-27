using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class RequestHandler : IHttpHandler
    {
        FrontControllerRequestFactory request_factory;
        FrontController front_controller;

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