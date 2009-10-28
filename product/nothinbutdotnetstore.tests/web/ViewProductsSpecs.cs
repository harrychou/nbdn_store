 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ViewProductsSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Products,
                                             DefaultProducts>
         {
        
         }

         [Concern(typeof(DefaultProducts))]
         public class when_request_for_products_is_made : concern
         {
             context c = () =>
             {
            
             };

             because b = () =>
             {
        
             };

        
             it should_display_all_products_in_the_department = () =>
             {
                 
            
            
             };
         }
     }

     public interface Products {}

     public class DefaultProducts: Products {}
 }
