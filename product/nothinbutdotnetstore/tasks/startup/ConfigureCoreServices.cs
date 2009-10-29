namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureCoreServices
    {
        public ContainerCoreService Service { get; set; }

        public ConfigureCoreServices() 
        {
            Service = new DefaultContainerCoreService();
        }

    }
}