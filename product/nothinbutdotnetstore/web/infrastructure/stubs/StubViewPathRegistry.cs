using System;
using System.Collections.Generic;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubViewPathRegistry : ViewPathRegistry
    {
        private Dictionary<Type, string> paths;

        public StubViewPathRegistry()
        {
            paths = new Dictionary<Type, string>
            {
                {typeof (IEnumerable<DepartmentItem>), "~/views/DepartmentBrowser.aspx"},
                {typeof (IEnumerable<ProductItem>), "~/views/ProductBrowser.aspx"}
            };
        }

        public string get_path_for_view_that_can_render<ViewModel>()
        {
            return paths[typeof(ViewModel)];
        }
    }
}