using System;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    class StubViewDepartmentService : ViewDepartmentService {
        public IEnumerable<string> GetDepartmentName()
        {
            return new List<string> {"Dept1", "Dept2"};
        }
    }
}