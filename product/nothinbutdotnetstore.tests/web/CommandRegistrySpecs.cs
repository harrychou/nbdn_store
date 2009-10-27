using System.Collections.Generic;
using System.Linq;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.core.extensions;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class CommandRegistrySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<CommandRegistry,
                                            DefaultCommandRegistry> {

            context c = () =>
            {
                request = an<Request>();
                all_commands = new List<Command>();
                provide_a_basic_sut_constructor_argument<IEnumerable<Command>>(all_commands);
            };

            static protected IList<Command> all_commands;
            static protected Request request;
            static protected Command result;
                                            }

        [Concern(typeof (DefaultCommandRegistry))]
        public class when_getting_a_command_for_a_request_and_it_has_the_command : concern
        {
            context c = () =>
            {
                command_that_can_handle_request = an<Command>();
                Enumerable.Range(1, 100).each(i => all_commands.Add(an<Command>()));
                all_commands.Add(command_that_can_handle_request);

                command_that_can_handle_request.Stub(command => command.can_handle(request)).Return(true);
            };

            because b = () =>
            {
                result = sut.get_command_that_can_process(request);
            };


            it should_return_the_command_to_the_client = () =>
            {
                result.should_be_equal_to(command_that_can_handle_request);
            };

            static Command command_that_can_handle_request;
        }

        [Concern(typeof (DefaultCommandRegistry))]
        public class when_getting_a_command_for_a_request_and_it_does_not_have_the_command : concern
        {
            because b = () =>
            {
                result = sut.get_command_that_can_process(request);
            };


            it should_return_a_missing_command_to_the_client = () =>
            {
                result.should_be_an_instance_of<MissingCommand>();
            };

        }
    }
}