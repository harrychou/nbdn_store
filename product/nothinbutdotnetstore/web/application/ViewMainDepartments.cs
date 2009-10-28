using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartments : ApplicationCommand
    {
        ResponseEngine _responseEngine;
        CatalogTasks service;

        public ViewMainDepartments()
            : this(new DefaultResponseEngine(), new StubViewMainDepartmentTasks()) {}

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