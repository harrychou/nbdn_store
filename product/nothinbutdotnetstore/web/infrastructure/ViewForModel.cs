using System.Web;
using System.Web.UI;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultViewForModel<ViewModel> : Page, ViewForModel<ViewModel>
    {
        public ViewModel model { get; set; }
    }

    public interface ViewForModel<ViewModel> : IHttpHandler
    {
        ViewModel model { get; set; }
    }
}