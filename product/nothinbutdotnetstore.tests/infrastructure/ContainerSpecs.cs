 using System;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using developwithpassion.commons.core.infrastructure.containers;
 using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
   public class ContainerSpecs
   {
     public abstract class concern : observations_for_a_sut_with_a_contract<Container,
                                       DefaultContainer>
     {
        
     }


     [Concern(typeof(DefaultContainer))]
     public class when_client_requesting_an_instance_any_class : concern
     {
       context c = () =>
       {
            
       };

       because b = () =>
       {
         //Container foo;
         //foo.
         result = (Simple) sut.instance_of(typeof (Simple));
       };

        
       it should_retrun_an_instance_of_a_type_with_only_a_default_constructor = () =>
       {
         result.should_be_an_instance_of<Simple>();
       };

       static Simple result;

     }

     [Concern(typeof(DefaultContainer))]
     public class when_client_requesting_an_generic_instance_with_default_constructor : concern
     {
       context c = () =>
       {
            
       };

       because b = () =>
       {
         //Container foo;
         //foo.
         result = sut.instance_of<Simple>();
       };

        
       it should_retrun_an_instance_of_a_type = () =>
       {
         result.should_be_an_instance_of<Simple>();
       };

       static Simple result;

     }


     [Concern(typeof(DefaultContainer))]
     public class when_client_requesting_an_instance_of_an_interface : concern
     {
       context c = () =>
       {
         interface_parameter = typeof (SimpleInterface);
         implementation_parameter = typeof (DefaultSimpleInterface);
       };

       because b = () =>
       {
         result = sut.instance_of<SimpleInterface>();
       };

       it should_retrun_an_instance_of_a_type_that_implements_the_interface = () =>
       {
         result.should_be_an_instance_of<DefaultSimpleInterface>();
       };

       public override Container create_sut()
       {
         return new DefaultContainer(interface_parameter, implementation_parameter);
       }

       static SimpleInterface result;
       static Type implementation_parameter;
       static Type interface_parameter;
     }
   }

   public class Simple
   {
   }

   public interface SimpleInterface
   { }

   public class DefaultSimpleInterface : SimpleInterface
   {
   }

 }
