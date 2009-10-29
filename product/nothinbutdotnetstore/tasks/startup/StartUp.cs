namespace nothinbutdotnetstore.tasks.startup
{
    public class StartUp
    {
        static public void run()
        {
            var container_service = new DefaultContainerCoreService();

            new ServiceTasks(container_service).Register();
            new ViewEngineComponents(container_service).Register();
            new CommandComponents(container_service).Register();
            new FrontControllerComponents(container_service).Register();
        }

    }
}