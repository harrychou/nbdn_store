 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.dto;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class DefaultRequestSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Request,
                                             DefaultRequest>
         {
        
         }

         [Concern(typeof(DefaultRequest))]
         public class when_mapping_from_request_to_input_model : concern
         {
             context c = () =>
             {
                 mapper_registry = the_dependency<MapperRegistry>();
                 mapper = an<Mapper<Request, DepartmentItem>>();

                 mapper_registry.Stub(registry => registry.get_mapper<Request, DepartmentItem>()).Return(mapper);

                 mapper.Stub(mapper1 => mapper1.map(sut)).Return(item);
             };

             because b = () =>
             {
                 item1 = sut.map<DepartmentItem>();
             };

        
             it should_delegate_to_specific_mapper = () =>
             {
                 item1.should_be_equal_to(item);
             };

             static MapperRegistry mapper_registry;
             static DepartmentItem item;
             static Mapper<Request, DepartmentItem> mapper;
             static DepartmentItem item1;
         }
     }
 }
