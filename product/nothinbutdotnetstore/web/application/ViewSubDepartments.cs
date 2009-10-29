using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartments : ApplicationCommand<CatalogTasks>
    {
        public ViewSubDepartments(ResponseEngine response_engine, CatalogTasks service)
            : base(response_engine, service)
        {
        }

        public override void process(Request request)
        {
            do_process(service.get_all_subdepartments_in(request.map<DepartmentItem>()));
        }

        public void do_process<ViewModel>(ViewModel data)
        {
            response_engine.display(data);
        }
    }
}