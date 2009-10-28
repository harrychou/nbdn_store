using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.tasks.stubs
{
    class StubViewMainDepartmentTasks : CatalogTasks
    {
        public IEnumerable<DepartmentItem> get_main_departments()
        {
            return Enumerable.Range(1, 100).Select(i => new DepartmentItem { name = i.ToString("Main department 0") });
        }
    }
}