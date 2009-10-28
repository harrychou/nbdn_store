using System;
using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubResult : Result
    {
        public void render()
        {
            HttpContext.Current.Items["data"] = data;
            HttpContext.Current.Response.Redirect("DepartmentBrowser.aspx");
        }

        public object data{get;set;}
    }
}