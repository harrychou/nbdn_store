using System;
using System.Collections.Generic;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultResponseEngine : ResponseEngine
    {
        ViewBuilder renderer;

        public DefaultResponseEngine(ViewBuilder renderer)
        {
            this.renderer = renderer;
        }

        public DefaultResponseEngine()
            : this(new DefaultViewBuilder("~/views/DepartmentBrowser.aspx"))
        {
        }

        public void display<ViewModel>(ViewModel model)
        {
            var view = renderer.build_view(model);
            view.display();
        }

    }
}