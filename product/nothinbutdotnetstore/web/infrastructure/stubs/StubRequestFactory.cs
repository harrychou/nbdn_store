using System;
using System.Web;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubRequestFactory : FrontControllerRequestFactory
    {
        public Request create_from(HttpContext http_context)
        {
            var url = http_context.Request.Url;

            Request result = null;

            if (url.PathAndQuery.Contains(DataKeys.view_sub_department_action))
            {
                throw new NotImplementedException();
            }

            if (url.PathAndQuery.Contains(DataKeys.view_main_department_action))
            {
                throw new NotImplementedException();
            }

            return result;
        }

        class StubRequest : Request
        {
            public string action_name { get; set; }

            public InputModel map<InputModel>()
            {
                throw new NotImplementedException();
            }
        }
    }
}