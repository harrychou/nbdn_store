using System;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsOfDepartment: ApplicationCommand
    {
        ResponseEngine _responseEngine;
        CatalogTasks service;

        public ViewProductsOfDepartment()
            : this(new DefaultResponseEngine(), new StubViewMainDepartmentTasks()) {}

        public ViewProductsOfDepartment(ResponseEngine _responseEngine, CatalogTasks service)
        {
            this._responseEngine = _responseEngine;
            this.service = service;
        }

        public void process(Request request)
        {
            _responseEngine.display(service.get_products_in_department(request.map<DepartmentItem>()));
        }
    }
}