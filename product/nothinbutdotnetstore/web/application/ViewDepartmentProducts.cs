using System;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewDepartmentProducts : ApplicationCommand {
        private readonly ResponseEngine response_engine;
        private readonly CatalogTasks catalog_tasks;

        public ViewDepartmentProducts(ResponseEngine response_engine, CatalogTasks catalog_tasks)
        {
            this.response_engine = response_engine;
            this.catalog_tasks = catalog_tasks;
        }

        public void process(Request request)
        {
            response_engine.display(catalog_tasks.get_all_products_in(request.map<DepartmentItem>()));
        }
    }
}