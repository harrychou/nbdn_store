using System;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartmentCommand: ApplicationCommand
    {
        ResponseEngine _responseEngine;
        CatalogTasks service;

        public ViewSubDepartmentCommand()
            : this(new DefaultResponseEngine(), new StubViewMainDepartmentTasks()) {}

        public ViewSubDepartmentCommand(ResponseEngine _responseEngine, CatalogTasks service)
        {
            this._responseEngine = _responseEngine;
            this.service = service;
        }

        public void process(Request request)
        {
            Request<string> validRequest = request as Request<string>;
            _responseEngine.display(service.get_sub_departments(validRequest.model));
        }
    }
}