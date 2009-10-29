 using System;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using developwithpassion.commons.core.infrastructure.containers;
 using nothinbutdotnetstore.infrastructure.containers.basic;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class DefaultContainerSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Container, DefaultContainer>
         {
             private context c = () =>
             {
                 implementation_registry = the_dependency<ActivatorRegistry>();
                 instance_activator = an<InstanceActivator>();
             };


             protected static ActivatorRegistry implementation_registry;
             protected  static InstanceActivator instance_activator;
        
         }

         [Concern(typeof(DefaultContainer))]
         public class when_requesting_an_instance_of_a_generic_type : concern
         {
             private context c = () =>
             {
                 instance = new OurClass();

                 implementation_registry.Stub(registry => registry.get_activator_for(typeof (OurClass))).Return(instance_activator);
                 instance_activator.Stub(activator => activator.create()).Return(instance);
             };

             because b = () =>
             {
                 result = sut.instance_of<OurClass>();
             };

        
             it should_return_an_instance_of_a_generic_type = () =>
             {
                 Console.WriteLine(result.GetType().Name);
                 result.should_be_an_instance_of<OurClass>();                           
            
             };

             static OurClass result;
             private static OurClass instance;
         }


         [Concern(typeof(DefaultContainer))]
         public class when_the_activator_for_a_type_cannot_successfully_create_the_instance : concern
         {
             private context c = () =>
             {
                 instance = new OurClass();

                 original_exception=new Exception();
                 implementation_registry.Stub(registry => registry.get_activator_for(typeof (OurClass))).Return(instance_activator);
                 instance_activator.Stub(activator => activator.create()).Throw(original_exception);
             };

             because b = () =>
             {
                 doing(() => sut.instance_of(typeof(OurClass)));
             };

        
             it should_throw_an_instance_creation_exception = () =>
             {
                 var creation_exception = exception_thrown_by_the_sut.should_be_an_instance_of<ActivatorCreationException>();
                 creation_exception.InnerException.should_be_equal_to(original_exception);
                 creation_exception.type_that_could_not_be_created.should_be_equal_to(typeof(OurClass));
             };

             static OurClass result;
             private static OurClass instance;
             static Exception original_exception;
         }

         [Concern(typeof(DefaultContainer))]
         public class when_requesting_an_instance_of_a_type : concern
         {
             private context c = () =>
             {
                 instance = new OurClass();

                 implementation_registry.Stub(registry => registry.get_activator_for(typeof (OurClass))).Return(instance_activator);
                 instance_activator.Stub(activator => activator.create()).Return
                     (instance);
             };

             because b = () =>
             {
                 result = sut.instance_of(typeof(OurClass));
             };


             it should_return_an_instance_of_a_type = () =>
             {
                 result.should_be_an_instance_of<OurClass>();

             };

             static object result;
             static OurClass instance;
         }

         [Concern(typeof(DefaultContainer))]
         public class when_requesting_an_instance_of_an_interface : concern
         {
             private context c = () =>
             {
                 instance = new SimpleInterfaceImplementation();

                 implementation_registry.Stub(registry => registry.get_activator_for(typeof (SimpleInterface))).Return(instance_activator);
                 instance_activator.Stub(activator => activator.create()).Return
                     (instance);
             };


             because b = () =>
             {
                 test = sut.instance_of(typeof(SimpleInterface));
             };


             it should_return_an_instance_of_a_type = () =>
             {
                 test.should_be_an_instance_of<SimpleInterfaceImplementation>();

             };

             static object test;
             protected  static SimpleInterface instance;
         }
     }

     public class OurClass {
         public OurClass() {}
     }

    public interface SimpleInterface{}
    public class SimpleInterfaceImplementation:SimpleInterface{}
 }
