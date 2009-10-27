using System;
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

                command = an<Command>();
                command_registry = the_dependency<CommandRegistry>();

                command_registry.Stub(factory => factory.get_command_that_can_process(request)).Return(command);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_delegate_the_processing_to_the_command_for_the_request = () =>
            {
                command.received(cmd => cmd.process(request));
            };

            it should_receive_a_command_from_factory = () => 
            {
                command.received(command1 => command1.process(request));
            };

            static Request request;

            static CommandRegistry command_registry;
            static Command command;
        }

    }
}