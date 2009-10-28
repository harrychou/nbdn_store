using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartments : ApplicationCommand
    {
        ResponseEngine response_engine;
        CatalogTasks service;

        public ViewSubDepartments()
            : this(new DefaultResponseEngine(), new StubViewMainDepartmentTasks()) {}

        public ViewSubDepartments(ResponseEngine _responseEngine, CatalogTasks service)
        {
            response_engine = _responseEngine;
            this.service = service;
        }

        public void process(Request request)
        {
            response_engine.display(service.get_all_subdepartments_in(request.map<DepartmentItem>()));
        }
    }
}