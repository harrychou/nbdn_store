using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewDepartmentProducts : ApplicationCommand<CatalogTasks> {

        public ViewDepartmentProducts(ResponseEngine response_engine, CatalogTasks service)
            : base(response_engine, service)
        {
        }

        public override void process(Request request)
        {
            response_engine.display(service.get_all_products_in(request.map<DepartmentItem>()));
        }
    }
}