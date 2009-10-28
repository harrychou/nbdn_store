using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks.stubs
{
    class StubViewMainDepartmentTasks : CatalogTasks
    {
        public IEnumerable<DepartmentItem> get_main_departments()
        {
            return Enumerable.Range(1, 100)
                .Select(i => new DepartmentItem { id = i.ToString(), name = i.ToString("Main department 0") });
        }

        public IEnumerable<DepartmentItem> get_sub_departments(string departmnent_id)
        {
            return Enumerable.Range(1, 10).Select(i => new DepartmentItem { id = i.ToString(), name = i.ToString("Sub department 0" + " for department " + departmnent_id) });
        }
    }
}