using System.Collections.Generic;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogTasks
    {
        IEnumerable<DepartmentItem> get_main_departments();
        IEnumerable<DepartmentItem> get_all_subdepartments_in(DepartmentItem department);

        IEnumerable<ProductItem> get_all_products_in(DepartmentItem department);
    }
}