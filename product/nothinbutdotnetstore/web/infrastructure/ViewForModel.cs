using System;
using System.Web;
using System.Web.UI;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultViewForModel<ViewModel> : Page, ViewForModel<ViewModel>
    {
        public ViewModel view_model{get;set;}

        public void display()
        {
            HttpContext.Current.Server.Transfer(this, true);
        }

    }

    public interface ViewForModel<ViewModel> : IHttpHandler
    {   
        
        ViewModel view_model{get;set;}

        void display();
    }
}