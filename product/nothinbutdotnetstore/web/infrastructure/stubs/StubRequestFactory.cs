using System;
using System.Security.Policy;
using System.Web;
using System.Web.UI.WebControls;
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
                var request = new StubRequest<string>();
                request.action_name = DataKeys.view_sub_department_action;

                var elements = url.PathAndQuery.Split('?');
                if (elements.Length > 1) request.model = elements[elements.Length - 1];

                result = request;
            }

            if (url.PathAndQuery.Contains(DataKeys.view_main_department_action))
            {
                var request = new StubRequest<object>();
                request.action_name = DataKeys.view_main_department_action;

                result = request;
            }

            return result;
        }

        class StubRequest<InputModel> : Request<InputModel>
        {


            public string action_name{get;set;}

            public InputModel model{get;set;}
        }
    }
}