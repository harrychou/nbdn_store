 namespace nothinbutdotnetstore.tests.web
 {   
   public class ViewModelDisplaySpecs
   {
     public abstract class concern : observations_for_a_sut_with_a_contract<contract_interface,
                                       contract_implementation>
     {
        
     }

     [Concern(typeof(contract_implementation))]
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
         
            
            
       };
     }
   }
 }
