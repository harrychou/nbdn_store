using System;
using System.Collections.Generic;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewDepartmentCommand: ApplicationCommand {

        readonly Result _result;
        readonly ViewDepartmentService _service;

        public ViewDepartmentCommand(Result result, ViewDepartmentService service)
        {
            _result = result;
            _service = service;
        }

        public ViewDepartmentCommand()
            : this(new StubResult(), new StubViewDepartmentService())
        {
        }

        public void process(Request request)
        {
            var departmentNames = _service.GetDepartmentName();
            _result.data = departmentNames;
            _result.render();
        }
    }
}