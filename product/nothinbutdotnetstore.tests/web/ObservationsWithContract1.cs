 using System;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ObservationsWithContract1
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Container,
             DefaultContainer>
         {
        
         }

         [Concern(typeof(DefaultContainer))]
         public class when_observation_name : concern
         {
             context c = () =>
             {
            
             };

             because b = () =>
             {
        
             };

        
             it first_observation = () =>
             {

                 throw new NotImplementedException();
            
            
             };
         }
     }
 }
