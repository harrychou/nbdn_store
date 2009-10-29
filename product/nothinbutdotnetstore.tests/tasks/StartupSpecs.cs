using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.tests.tasks
{
    public class StartupSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (StartUp))]
        public class when_completed : concern
        {
            because b = () =>
            {
                StartUp.run();
            };


            it should_be_able_to_access_key_application_services = () =>
            {
                IOC.resolve.instance_of<FrontController>().should_not_be_an_instance_of<DefaultFrontController>();
            };
        }
    }
}