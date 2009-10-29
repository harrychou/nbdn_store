namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        static public StartupCommandChain by_running<T>() where T : StartupCommand
        {
            return new StartupCommandChain(new StartupCommandFactory(), typeof (T));
        }
    }
}