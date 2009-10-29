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
}