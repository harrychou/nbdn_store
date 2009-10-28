using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application
{
    public interface ViewDepartmentService {
        IEnumerable<string> GetDepartmentName();
    }
}