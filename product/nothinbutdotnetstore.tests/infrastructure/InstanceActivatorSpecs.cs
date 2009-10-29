using System;
using System.Reflection;
using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.containers.basic;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class InstanceActivatorSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<InstanceActivator,
             DefaultInstanceActivator>
         {
        
         }

         [Concern(typeof(DefaultInstanceActivator))]
         public class when_creating_an_instance_of_a_type : concern
         {
             context c = () =>
             {
                 activator = () => new Simple();
                 provide_a_basic_sut_constructor_argument(activator);
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
             private static ActivationInfo activation_information;
             private static Simple instance;
             private static Func<object> activator;
         }

         public class Simple{}
     }
 }
