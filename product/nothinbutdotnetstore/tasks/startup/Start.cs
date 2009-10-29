namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        public static StartupCommandChain by_running<T>() where T : ConfigureCoreServices, new()
        {
            return new StartupCommandChain(new T());
        }
    }
}