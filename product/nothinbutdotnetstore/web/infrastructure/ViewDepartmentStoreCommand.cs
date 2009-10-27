namespace nothinbutdotnetstore.web.infrastructure
{
    public class ViewDepartmentStoreCommand : Command
    {
        readonly string request_name;
        readonly DepartmentStoreService service;

        public ViewDepartmentStoreCommand(string request_name) : this( request_name, new DefaultDepartmentStoreService())
        {}

        public ViewDepartmentStoreCommand(string request_name, DepartmentStoreService service)
        {
            this.request_name = request_name;
            this.service = service;
        }

        public object process(Request request)
        {
            return service.get_main_department_stores();
        }

        public bool can_handle(Request request)
        {
            return request.name == request_name;
        }
    }
}