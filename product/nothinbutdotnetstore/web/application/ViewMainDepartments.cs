using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartments : ApplicationCommand
    {
        Result result;
        CatalogTasks service;

        public ViewMainDepartments()
            : this(new StubResult(), new StubViewMainDepartmentTasks()) {}

        public ViewMainDepartments(Result result, CatalogTasks service)
        {
            this.result = result;
            this.service = service;
        }

        public void process(Request request)
        {
            result.render(service.get_main_departments());
        }
    }
}