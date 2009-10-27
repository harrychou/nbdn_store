using System;
using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class RequestHandler : IHttpHandler
    {
        FrontControllerRequestFactory request_factory;
        FrontController front_controller;

        public RequestHandler(FrontControllerRequestFactory requestFactory, FrontController frontController)
        {
            this.request_factory = requestFactory;
            this.front_controller = frontController;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_from(context));
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}