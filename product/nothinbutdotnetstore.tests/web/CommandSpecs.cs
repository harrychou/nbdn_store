using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.infrastructure;
using developwithpassion.bdd.mocking.rhino;

namespace nothinbutdotnetstore.tests.web
{
    public class CommandSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Command,
                                            DefaultCommand> {

            context c = () =>
            {
                provide_a_basic_sut_constructor_argument<Predicate<Request>>(request1 => true);
            };
        }

        [Concern(typeof (DefaultCommand))]
        public class when_determining_if_it_can_process_a_request : concern
        {
            context c = () =>
            {
                request = an<Request>();
            };


            because b = () =>
            {
                result = sut.can_handle(request);
            };


            it should_make_the_determination_by_leveraging_its_request_specification = () =>
            {
                result.should_be_true();
            };

            static bool result;
            static Request request;
        }

        [Concern(typeof (DefaultCommand))]
        public class when_processing_a_request : concern
        {
            context c = () =>
            {
                request = an<Request>();
                application_command = the_dependency<ApplicationCommand>();
            };


            because b = () =>
            {
                sut.process(request);
            };


            it should_delegate_the_processing_to_the_application_specific_command = () =>
            {
                application_command.received(command => command.process(request));
            };

            static bool result;
            static Request request;
            static ApplicationCommand application_command;
        }
    }
}