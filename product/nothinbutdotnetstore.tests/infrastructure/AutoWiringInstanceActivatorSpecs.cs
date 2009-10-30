using System.Data;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.tests.utility;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class AutoWiringInstanceActivatorSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<InstanceActivator,
                                            AutoWiringInstanceActivator> {}

        [Concern(typeof (AutoWiringInstanceActivator))]
        public class when_creating_of_instance_of_a_type_with_dependencies : concern
        {
            context c = () =>
            {
                constructor_resolver = the_dependency<ConstructorResolver>();
                constructor_resolver.Stub(resolver => resolver.pick_constructor_for(typeof(OurItemWithDependencies))).Return(typeof(OurItemWithDependencies).greediest_contructor());
                connection = container_dependency<IDbConnection>();
                command = container_dependency<IDbCommand>();
                reader = container_dependency<IDataReader>();
                another_dependency = container_dependency<AnotherDependency>();

                provide_a_basic_sut_constructor_argument(typeof(OurItemWithDependencies));
            };

            because b = () =>
            {
                sut.create();
            };


            it should_create_the_instance_of_the_type_providing_all_the_dependencies_required_by_the_required_constructor = () =>
            {
                var item_with_dependencies = result.should_be_an_instance_of<OurItemWithDependencies>();
                item_with_dependencies.connection.should_be_equal_to(connection);
                item_with_dependencies.command.should_be_equal_to(command);
                item_with_dependencies.reader.should_be_equal_to(reader);
                item_with_dependencies.another_dependency.should_be_equal_to(another_dependency);
            };

            static OurItemWithDependencies result;
            static ConstructorResolver constructor_resolver;
            static IDbConnection connection;
            static IDbCommand command;
            static IDataReader reader;
            static AnotherDependency another_dependency;
        }

        public class OurItemWithDependencies
        {
            public IDbConnection connection;
            public IDbCommand command;
            public IDataReader reader;
            public AnotherDependency another_dependency;

            public OurItemWithDependencies(IDbConnection connection, IDbCommand command, IDataReader reader, AnotherDependency another_dependency)
            {
                this.connection = connection;
                this.another_dependency = another_dependency;
                this.command = command;
                this.reader = reader;
            }
        }

        public class AnotherDependency
        {

            public AnotherDependency()
            {
            }
        }
    }
}