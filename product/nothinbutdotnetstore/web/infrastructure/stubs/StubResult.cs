using System;
using System.Web;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubResult : Result
    {
        public void render(object data)
        {
            HttpContext.Current.Items[DataKeys.departments] = data;
            HttpContext.Current.Server.Transfer("DepartmentBrowser.aspx");
        }

    }
}