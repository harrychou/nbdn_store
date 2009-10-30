using System;
using System.IO;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartUp
    {
        static string pipeline_configuration_file= Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pipeline_configuration.txt");

        static public void run()
        {
            Start.by_running_all_commands_in(pipeline_configuration_file);
        }
    }
}