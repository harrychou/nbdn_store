using System;
using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubRequestFactory : FrontControllerRequestFactory
    {
        public Request create_from(HttpContext http_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request {
            public string name
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }
        }
    }
}