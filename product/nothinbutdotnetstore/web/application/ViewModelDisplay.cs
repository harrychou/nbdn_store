using System;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewModelDisplay<ViewModel> : ApplicationCommand
    {
        ResponseEngine response_engine;
        Func<Request, ViewModel> model_query;

        public ViewModelDisplay(ResponseEngine response_engine, Func<Request, ViewModel> model_query)
        {
            this.response_engine = response_engine;
            this.model_query = model_query;
        }
        
        public void process(Request request)
        {
            response_engine.display(model_query(request));
        }
    }

    public class ViewModelDisplay<ViewModel, ServiceComponent> : ApplicationCommand
    {
        ResponseEngine response_engine;
        readonly ServiceComponent component;
        Func<Request, ServiceComponent, ViewModel> model_query;

        public ViewModelDisplay(ResponseEngine response_engine, ServiceComponent component, Func<Request, ServiceComponent, ViewModel> model_query)
        {
            this.response_engine = response_engine;
            this.component = component;
            this.model_query = model_query;
        }

        public void process(Request request)
        {
            response_engine.display(model_query(request, component));
        }
    }
}