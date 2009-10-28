using System;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubViewPathRegistry : ViewPathRegistry
    {
        public string get_path_for_view_that_can_render<ViewModel>()
        {
            return "~/views/DepartmentBrowser.aspx";
        }
    }
}