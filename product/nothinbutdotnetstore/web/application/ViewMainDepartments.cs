using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartments : ApplicationCommand<CatalogTasks>
    {
        public ViewMainDepartments(ResponseEngine response_engine, CatalogTasks service)
            : base(response_engine, service) 
        {}

        public override void process(Request request)
        {
            response_engine.display(service.get_main_departments());
        }
    }
}