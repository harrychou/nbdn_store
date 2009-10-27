using System;
using System.Data;
using System.Security.Principal;
using System.Threading;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class SomethingSpecs
    {
        public class concern : observations_for_a_sut_with_a_contract<Something, DefaultSomething> {

        }

        public class when_observation_name : concern
        {
            context c = () =>
            {
                number = 23;
                connection = the_dependency<IDbConnection>();
                command = an<IDbCommand>();
                provide_a_basic_sut_constructor_argument(number);
                provide_a_basic_sut_constructor_argument("blah");
                my_principal = an<IPrincipal>();

                connection.Stub(db_connection => db_connection.CreateCommand()).Return(command);

                change(() => Thread.CurrentPrincipal).to(my_principal);
            };

//            public override Something create_sut()
//            {
//                throw new NotImplementedException();
//            }

            after_the_sut_has_been_created ac = () =>
            {
                
            };

            because b = () =>
            {
                result = sut.other_calculate();
            };

            it should_do_something = () =>
            {
                result.should_be_equal_to(2);
            };

            it should_open_the_connection_to_the_db = () =>
            {
                connection.received(x => x.Open());
            };

            it should_run_the_command = () =>
            {
                command.received(db_command => db_command.ExecuteNonQuery());
            };

            static int result;
            static int number;
            static IDbConnection connection;
            static IDbCommand command;
            static IPrincipal my_principal;
        }
    }


    public interface Something
    {
        int calculate();
        int other_calculate();
    }

    public class DefaultSomething : Something
    {
        string message;
        IDbConnection connection;
        int number;

        public DefaultSomething(int number, string message, IDbConnection connection)
        {
            this.message = message;
            this.connection = connection;
            this.number = number;
        }

        public int calculate()
        {
            connection.Open();
            return 1;
        }

        public int other_calculate()
        {
            connection.Open();
            connection.CreateCommand().ExecuteNonQuery();
            return 2;
        }
    }
}