using System;
using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class FunctionalActivatorSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<InstanceActivator,
             FunctionalInstanceActivator>
         {
        
         }

         [Concern(typeof(FunctionalInstanceActivator))]
         public class when_creating_an_instance_of_a_type : concern
         {
             context c = () =>
             {
                 provide_a_basic_sut_constructor_argument<Func<object>>(() => new Simple());
             };

             because b = () =>
             {
                 result = sut.create();
             };
        
             it should_return_an_instance_of_the_correct_type = () =>
             {
                 result.should_be_an_instance_of<Simple>();
             };

             static object result;
             private static Simple instance;
         }

         public class Simple{}
     }
 }
