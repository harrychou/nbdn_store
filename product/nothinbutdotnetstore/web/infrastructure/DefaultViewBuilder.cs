using System.Web.Compilation;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultViewBuilder : ViewBuilder {
        string virtual_path;

        public DefaultViewBuilder(string virtual_path)
        {
            this.virtual_path = virtual_path;
        }


        public ViewForModel<ViewModel> build_view<ViewModel>(ViewModel model)
        {
            var page = 
                BuildManager.CreateInstanceFromVirtualPath(
                    virtual_path,
                    typeof(DefaultViewForModel<ViewModel>)) as DefaultViewForModel<ViewModel>;

            page.view_model = model;

            return page;
        }

    }
}