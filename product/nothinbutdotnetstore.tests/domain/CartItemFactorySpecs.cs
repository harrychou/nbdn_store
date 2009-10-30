 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.domain;

namespace nothinbutdotnetstore.tests.domain
 {   
     public class CartItemFactorySpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<CartItemFactory>
         {
        
         }

         [Concern(typeof(CartItemFactory))]
         public class when_creating_a_new_cart_item : concern
         {
             context c = () =>
             {
                 product_to_add_to_cart_item = an<Product>();
                 quantity_of_product_to_add = 37;
             };

             because b = () =>
             {
                 result = sut.create_item_for(product_to_add_to_cart_item, quantity_of_product_to_add);
             };

        
             it should_create_a_cart_item_that_contains_the_product_and_quantity = () =>
             {
                 result.product.should_be_equal_to(product_to_add_to_cart_item);
                 result.quantity.should_be_equal_to(quantity_of_product_to_add);
             };

             private static CartItem result;
             private static Product product_to_add_to_cart_item;
             private static int quantity_of_product_to_add;
         }
     }
 }
