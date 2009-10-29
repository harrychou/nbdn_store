 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class DefaultContainerSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ContainerInterface, DefaultContainer>
         {
        
         }

         [Concern(typeof(DefaultContainer))]
         public class when_requesting_an_instance_of_a_generic_type : concern
         {
             because b = () =>
             {
                 result = sut.instance_of<OurClass>();
             };

        
             it should_return_an_instance_of_a_generic_type = () =>
             {
                 result.should_be_an_instance_of<OurClass>();                           
            
             };

             static OurClass result;
         }

         [Concern(typeof(DefaultContainer))]
         public class when_requesting_an_instance_of_a_type : concern
         {
             because b = () =>
             {
                 test = sut.instance_of(typeof(OurClass));
             };


             it should_return_an_instance_of_a_type = () =>
             {
                 test.should_be_an_instance_of<OurClass>();

             };

             static object test;
         }
     }

     public class OurClass {
         public OurClass() {}
     }
 }
