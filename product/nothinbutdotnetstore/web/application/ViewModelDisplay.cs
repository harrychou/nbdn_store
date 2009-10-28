using System;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewModelDisplay<ViewModel> : ApplicationCommand {
        ResponseEngine response_engine;
        private readonly Func<Request, ViewModel> accessor;

        public ViewModelDisplay(ResponseEngine response_engine, Func<Request, ViewModel> accessor)
        {
            this.response_engine = response_engine;
            this.accessor = accessor;
        }

        public void process(Request request)
        {
            response_engine.display(accessor(request));
        }
    }
}