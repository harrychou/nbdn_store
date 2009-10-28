using System.Collections.Generic;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogTasks
    {
        IEnumerable<DepartmentItem> get_main_departments();
        IEnumerable<DepartmentItem> get_sub_departments(string departmnent_id);
    }
}