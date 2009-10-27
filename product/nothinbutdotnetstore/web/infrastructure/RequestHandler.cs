using System;
using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class RequestHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}