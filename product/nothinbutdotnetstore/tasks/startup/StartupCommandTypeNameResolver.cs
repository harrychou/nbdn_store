using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandTypeNameResolverer : Mapper<string, string>
    {
        public string map(string short_name)
        {
            return string.Format("{0}.{1}", typeof (StartupCommand).Namespace, short_name);
        }
    }
}