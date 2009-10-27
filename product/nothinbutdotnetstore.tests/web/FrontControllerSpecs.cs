using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class FrontControllerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<FrontController, DefaultFrontController> {}

        [Concern(typeof (FrontController))]
        public class when_processing_a_request : concern
        {
            context c = () =>
            {
                request = an<Request>();
                command_factory = the_dependency<CommandFactory>();
                command = an<Command>();
                command_factory.Stub(factory => factory.create_from(request)).Return(command);
            };

            because b = () =>
            {
                sut.process(request);
            };

            it should_delegate_the_command_selection_to_the_command_factory = () =>
            {
                command_factory.received(factory => factory.create_from(request));
            };

            it should_receive_a_command_from_factory = () => 
            {
                command.received(command1 => command1.process(request));
            };

            static Request request;
            static CommandFactory command_factory;
            static Command command;
        }
    }
}