using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartments : ApplicationCommand
    {
        ResponseEngine _responseEngine;
        CatalogTasks service;

        public ViewMainDepartments(ResponseEngine _responseEngine, CatalogTasks service)
        {
            this._responseEngine = _responseEngine;
            this.service = service;
        }

        public void process(Request request)
        {
            _responseEngine.display(service.get_main_departments());
        }
    }
}