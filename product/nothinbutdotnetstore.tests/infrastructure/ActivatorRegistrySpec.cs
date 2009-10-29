 using System;
 using System.Collections.Generic;
 using System.Linq;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.core.extensions;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.containers.basic;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class ActivatorRegistrySpec
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ActivatorRegistry,
                                             DefaultActivatorRegistry>
         {
             context c = () =>
             {
                 all_activators = new Dictionary<Type, InstanceActivator>();
                 provide_a_basic_sut_constructor_argument(all_activators);


             };

             static protected Dictionary<Type, InstanceActivator> all_activators;

             static protected InstanceActivator result;
         }

         [Concern(typeof(DefaultActivatorRegistry))]
         public class when_getting_an_activator_for_a_type_and_it_has_the_activator : concern
         {
             context c = () =>
             {

                 activator_that_can_instantiate_the_type = an<InstanceActivator>();
                 all_activators.Add(typeof(SimpleInterfaceImplementation), activator_that_can_instantiate_the_type);
                 activator_that_can_instantiate_the_type.Stub(activator => activator.create()).Return(activator_that_can_instantiate_the_type);

             };

             because b = () =>
             {
                 result = sut.get_activator_for(typeof(SimpleInterfaceImplementation));
             };


             it should_return_the_activator_to_the_client = () =>
             {
                 result.should_be_equal_to(activator_that_can_instantiate_the_type);
             };

             static InstanceActivator activator_that_can_instantiate_the_type;
             static SimpleInterfaceImplementation basicObject;
         }

         public interface SimpleInterface { }
         public class SimpleInterfaceImplementation : SimpleInterface { }

     }

 }
