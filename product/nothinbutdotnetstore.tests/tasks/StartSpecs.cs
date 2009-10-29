using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tests.tasks
{
    public class StartSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (Start))]
        public class when_chaining_a_list_of_command : concern
        {
            context c = () => 
            {
            };

            because b = () => 
            {
                Start.by_running<FirstCommand>().followed_by<LastCommand>().finish_by<LastCommand>();
            };

            it should_called_first_command_then_last_command = () =>
            {
                FirstCommand.times_called.should_be_equal_to(0);
                LastCommand.times_called.should_be_equal_to(2);
            };
        }
    }

    class FirstCommand : ConfigureCoreServices
    {
        static public int times_called = 0;
        public FirstCommand(ContainerCoreService core_service) : base(core_service) {}

        public void run()
        {
            times_called += 1;
        }
    }

    class LastCommand : StartupCommand
    {
        static public int times_called = 0;
        readonly ContainerCoreService service;

        public LastCommand(ContainerCoreService service)
        {
            this.service = service;
        }

        public void run()
        {
            times_called += 1;
        }
    }
}
