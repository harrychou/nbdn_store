 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.domain;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.domain
 {   
     public class CartItemSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<CartItem>
         {
        
         }

         [Concern(typeof(CartItem))]
         public class when_the_quantity_is_increased : concern
         {
             context c = () =>
             {
                 starting_quantity = 5;
                 quantity_to_increment = 11;
                 provide_a_basic_sut_constructor_argument(starting_quantity);
                 provide_a_basic_sut_constructor_argument(an<Product>());
             };

             because b = () =>
             {
                 sut.increment_quantity_by(quantity_to_increment);        
             };

        
             it should_increase_the_quantity_by_the_increase_amount = () =>
             {
                 sut.quantity.should_be_equal_to(starting_quantity+quantity_to_increment);
             };

             private static int starting_quantity;
             private static int quantity_to_increment;
         }

         [Concern(typeof(CartItem))]
         public class when_checking_to_see_if_the_product_in_the_cart_item_is_in_the_cart_item : concern
         {
             context c = () =>
             {
                 product_to_check_for = the_dependency<Product>();
                 provide_a_basic_sut_constructor_argument(1);
             };

             because b = () =>
             {
                 result = sut.is_item_for(product_to_check_for);
             };

        
             it should_return_true = () =>
             {
                 result.should_be_equal_to(true);
             };

             private static bool result;
             private static Product product_to_check_for;
         }

         [Concern(typeof(CartItem))]
         public class when_checking_to_see_if_a_product_not_in_the_cart_item_is_in_the_cart_item : concern
         {
             context c = () =>
             {
                 product_not_on_the_cart_item = an<Product>();
                  
                 provide_a_basic_sut_constructor_argument(1);
                 provide_a_basic_sut_constructor_argument(an<Product>());
             };

             because b = () =>
             {
                 result = sut.is_item_for(product_not_on_the_cart_item);
             };

        
             it should_return_false = () =>
             {
                 result.should_be_equal_to(false);
             };

             private static bool result;
             private static Product product_not_on_the_cart_item;
         }

         [Concern(typeof(CartItem))]
         public class when_changing_the_quantity_to_a_new_value : concern
         {
             context c = () =>
             {
                 quantity_to_change_to = 5;

                 provide_a_basic_sut_constructor_argument(1);
                 provide_a_basic_sut_constructor_argument(an<Product>());
             };

             because b = () =>
             {
                 sut.change_quantity_to(quantity_to_change_to);
             };

        
             it should_reflect_the_new_quantity = () =>
             {
                sut.quantity.should_be_equal_to(quantity_to_change_to);                 
             };

             private static int quantity_to_change_to;
         }

         [Concern(typeof(CartItem))]
         public class when_calculating_the_total_cost : concern
         {
             context c = () =>
             {
                 product = the_dependency<Product>();
                 quantity = 5;
                 product.Stub(prod => prod.price).Return(17.50m);
                 provide_a_basic_sut_constructor_argument(quantity);
             };

             because b = () =>
             {
                 result = sut.calculate_total_cost();
             };

        
             it should_return_the_product_price_times_the_quantity = () =>
             {
                 result.should_be_equal_to(product.price * quantity);
             };

             private static decimal result;
             private static Product product;
             private static int quantity;
         }

     }
 }
