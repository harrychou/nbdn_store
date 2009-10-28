using System.Web.Compilation;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultViewFactory : ViewFactory
    {
        ViewPathRegistry view_path_registry;
        PageFactory page_factory;

        public DefaultViewFactory():this(new StubViewPathRegistry(), 
            BuildManager.CreateInstanceFromVirtualPath)
        {
        }

        public DefaultViewFactory(ViewPathRegistry view_path_registry,PageFactory page_factory)
        {
            this.view_path_registry = view_path_registry;
            this.page_factory = page_factory;
        }

        public ViewForModel<ViewModel> create_view_for<ViewModel>(ViewModel model)
        {
            var page = (ViewForModel<ViewModel>)page_factory(view_path_registry.get_path_for_view_that_can_render<ViewModel>(),
                                    typeof (DefaultViewForModel<ViewModel>));


            page.model = model;

            return page;
        }
    }
}