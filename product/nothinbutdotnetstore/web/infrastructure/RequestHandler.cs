using System;
using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class RequestHandler : IHttpHandler
    {
        private readonly FrontControllerRequestFactory requestFactory;
        private readonly FrontController frontController;

        public RequestHandler(FrontControllerRequestFactory requestFactory, FrontController frontController)
        {
            this.requestFactory = requestFactory;
            this.frontController = frontController;
        }

        public void ProcessRequest(HttpContext context)
        {
            var request = requestFactory.create_from(context);
            frontController.process(request);
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}