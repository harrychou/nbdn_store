 using System;
 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class ActivatorRegistrySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ActivatorRegistry,
                                             DefaultActivatorRegistry>
         {
             context c = () =>
             {
                 all_activators = new Dictionary<Type, InstanceActivator>();
                 provide_a_basic_sut_constructor_argument(all_activators);


             };

             static protected IDictionary<Type, InstanceActivator> all_activators;

             static protected InstanceActivator result;
         }

         [Concern(typeof(DefaultActivatorRegistry))]
         public class when_getting_an_activator_for_a_type_and_it_has_the_activator : concern
         {
             context c = () =>
             {

                 activator_that_can_instantiate_the_type = an<InstanceActivator>();
                 all_activators.Add(typeof(SimpleInterfaceImplementation), activator_that_can_instantiate_the_type);
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

         [Concern(typeof(DefaultActivatorRegistry))]
         public class when_getting_an_activator_for_a_type_and_it_does_not_have_the_activator : concern
         {
             context c = () =>
             {
                 activator_that_can_instantiate_the_type = an<InstanceActivator>();
                 registry = the_dependency<IDictionary<Type, InstanceActivator>>();
             };

             because b = () =>
             {
                 doing(() => result = sut.get_activator_for(typeof(SimpleInterfaceImplementation)));
             };


             it should_return_the_activator_to_the_client = () =>
             {
                 exception_thrown_by_the_sut.should_be_an_instance_of<ActivatorNotFoundException>();
             };

             static InstanceActivator activator_that_can_instantiate_the_type;
             static SimpleInterfaceImplementation basicObject;
             static IDictionary<Type, InstanceActivator> registry;
         }

         public interface SimpleInterface { }
         public class SimpleInterfaceImplementation : SimpleInterface { }

     }

 }
