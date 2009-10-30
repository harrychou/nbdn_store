using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.tasks
 {   
     public class ShoppingCartTaskSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ShoppingCartTask,
             DefaultShoppingCartTask>
         {
        
         }

         [Concern(typeof(DefaultShoppingCartTask))]
         public class when_an_item_is_added_to_the_shopping_cart : concern
         {
             context c = () =>
             {
                 shopping_cart = the_dependency<ShoppingCart>();
                 catalog = the_dependency<Catalog>();

                 product_to_be_added = an<Product>();
                 line_item_to_add = new LineItem
                 {
                     product_id = 1,
                     quantity = 5
                 };

                 catalog.Stub(cat => cat.get_product(line_item_to_add.product_id)).Return(product_to_be_added);
            
             };

             because b = () =>
             {
                sut.add_product_to_cart(line_item_to_add);
             };

        
             it should_add_a_product_and_quantity_to_the_shopping_cart = () =>
             {
                 shopping_cart.received(cart => cart.add_item(product_to_be_added, line_item_to_add.quantity));
             };

             private static ShoppingCart shopping_cart;
             private static Product product_to_be_added;
             private static LineItem line_item_to_add;
             private static Catalog catalog;
         }
     }
 }
