using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Request,
                                            DefaultRequest> {}

        [Concern(typeof (DefaultRequest))]
        public class when_mapping_from_request_to_input_model : concern
        {
            context c = () =>
            {
                mapper_registry = the_dependency<MapperRegistry>();
                mapper = an<Mapper<Request, ItemToMap>>();
                item = new ItemToMap();
                mapper_registry.Stub(registry => registry.get_mapper<Request, ItemToMap>()).Return(mapper);
                mapper.Stub(mapper1 => mapper1.map(Arg<Request>.Is.NotNull)).Return(item);
            };

            because b = () =>
            {
                result = sut.map<ItemToMap>();
            };


            it should_delegate_to_specific_mapper = () =>
            {
                result.should_be_equal_to(item);
            };

            static MapperRegistry mapper_registry;
            static ItemToMap item;
            static Mapper<Request, ItemToMap> mapper;
            static ItemToMap result;
        }

        public class ItemToMap {}
    }
}