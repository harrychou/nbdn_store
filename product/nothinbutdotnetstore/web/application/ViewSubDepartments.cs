using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartments : ApplicationCommand
    {
        ResponseEngine response_engine;
        CatalogTasks service;

        public ViewSubDepartments(ResponseEngine _responseEngine, CatalogTasks service)
        {
            response_engine = _responseEngine;
            this.service = service;
        }

        public void process(Request request)
        {
            do_process(service.get_all_subdepartments_in(request.map<DepartmentItem>()));
        }

        public void do_process<ViewModel>(ViewModel data)
        {
            response_engine.display(data);
        }
    }
}