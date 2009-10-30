 using System.Collections.Generic;
 using System.Linq;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.domain;
 using Rhino.Mocks;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdd.core.extensions;

namespace nothinbutdotnetstore.tests.domain
 {   
     public class ShoppingCartSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<ShoppingCart>
         {

             context c = () =>
             {
                 cart_items = new List<CartItem>();
                 cart_item_factory = the_dependency<CartItemFactory>();
                 provide_a_basic_sut_constructor_argument(cart_items);
             };

             static protected CartItemFactory cart_item_factory;
             static protected IList<CartItem> cart_items;
         }

         [Concern(typeof(ShoppingCart))]
         public class when_adding_a_product_to_an_empty_shopping_cart : concern
         {
             context c = () =>
             {
                 product = an<Product>();
                 item = an<CartItem>();
                 cart_item_factory.Stub(factory => factory.create_item_for(product, 23)).Return(item);
             };

             because b = () =>
             {
                 sut.add(product,23);
             };

        
             it should_store_the_item_created_to_store_the_product_and_its_quantity = () =>
             {
                cart_items.should_contain(item);
             };

             static CartItem item;
             static Product product;
         }

         public abstract class concern_for_cart_with_a_bar_of_dairy_milk_in_it:concern
         {
             context c = () =>
             {
                 dairy_milk_item = an<CartItem>();
                 dairy_milk = an<Product>();

                 dairy_milk_item.Stub(item => item.is_item_for(dairy_milk)).Return(true);

                 cart_items.Add(dairy_milk_item);
             };
             
             static protected CartItem dairy_milk_item;
             static protected Product dairy_milk;
         }
         [Concern(typeof(ShoppingCart))]
         public class when_adding_an_product_that_is_already_in_the_cart : concern_for_cart_with_a_bar_of_dairy_milk_in_it
         {
             because b = () =>
             {
                 sut.add(dairy_milk,23);
             };

        
             it should_increment_the_quantity_of_the_cart_item_for_the_product = () =>
             {
                 dairy_milk_item.received(cart_item => cart_item.increment_quantity_by(23));
             };
         }

         [Concern(typeof(ShoppingCart))]
         public class when_adding_a_product_this_is_not_in_the_cart_to_a_non_empty_cart : concern_for_cart_with_a_bar_of_dairy_milk_in_it
         {
             context c = () =>
             {
                 bag_of_ruffles = an<Product>();
                 item_for_ruffles = an<CartItem>();
                 cart_item_factory.Stub(factory => factory.create_item_for(bag_of_ruffles, 23)).Return(item_for_ruffles);
             };

             because b = () =>
             {
                 sut.add(bag_of_ruffles,23);
             };

        
             it should_create_and_store_an_item_for_the_new_product_and_its_quantity = () =>
             {
                 cart_items.Count.should_be_equal_to(2);
                 cart_items.should_contain(item_for_ruffles);
             };

             static Product bag_of_ruffles;
             static CartItem item_for_ruffles;
         }

         [Concern(typeof(ShoppingCart))]
         public class when_changing_the_quantity_of_a_product_in_the_cart : concern_for_cart_with_a_bar_of_dairy_milk_in_it
         {
             because b = () =>
             {
                 sut.change_quantity(dairy_milk, 42);
             };

        
             it should_increment_the_quantity_on_the_item_for_the_product = () =>
             {
                 dairy_milk_item.received(item => item.change_quantity_to(42));
             };

         }

         [Concern(typeof(ShoppingCart))]
         public class when_removing_a_product_that_is_in_the_cart : concern_for_cart_with_a_bar_of_dairy_milk_in_it
         {
             because b = () =>
             {
                 sut.remove(dairy_milk);
             };

        
             it should_remove_the_item_for_the_product = () =>
             {
                 cart_items.Count.should_be_equal_to(0);
             };

         }

         [Concern(typeof(ShoppingCart))]
         public class when_emptying_the_cart : concern_for_cart_with_a_bar_of_dairy_milk_in_it
         {
             context c = () =>
             {
                 Enumerable.Range(1,100).each(i => cart_items.Add(an<CartItem>()));
             };
             because b = () =>
             {
                 sut.empty();
             };

        
             it should_remove_all_items_from_the_cart = () =>
             {
                 cart_items.Count.should_be_equal_to(0);
             };

         }

         [Concern(typeof(ShoppingCart))]
         public class when_calculating_the_total_cost_of_the_items_in_the_cart : concern
         {
             context c = () =>
             {
                 Enumerable.Range(1,100).each(i =>
                 {
                     var cart_item = an<CartItem>();
                     fixed_cost = 10m;
                     cart_item.Stub(item => item.calculate_total_cost()).Return(fixed_cost);
                     cart_items.Add(cart_item);
                 });
             };
             because b = () =>
             {
                 result = sut.calculate_total_cost();
             };

        
             it should_return_the_sum_of_the_total_cost_of_all_the_items = () =>
             {
                 result.should_be_equal_to(cart_items.Count * fixed_cost);
             };

             static decimal result;
             static decimal fixed_cost;
         }
     }
 }
