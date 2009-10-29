using System;
using System.IO;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartUp
    {
        static string pipeline_configuration_file= Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "startup_pipeline.txt");

        static public void run()
        {
            Start.by_running_all_commands_in(pipeline_configuration_file);
        }

        static void specific()
        {
            Start.by_running<ConfigureCoreServices>()
                .followed_by<ConfigureServiceLayer>()
                .followed_by<ConfigureViewEngine>()
                .followed_by<ConfigureFrontController>()
                .finish_by<ConfigureApplicationRoutes>();
        }
    }
}