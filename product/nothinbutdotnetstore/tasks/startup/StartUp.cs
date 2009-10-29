namespace nothinbutdotnetstore.tasks.startup
{
    public class StartUp
    {
        static public void run()
        {
            Start.by_running<ConfigureCoreServices>()
                .followed_by<ConfigureServiceLayer>()
                .followed_by<ConfigureViewEngine>()
                .followed_by<ConfigureFrontController>()
                .finish_by<ConfigureApplicationRoutes>();

        }
    }
}