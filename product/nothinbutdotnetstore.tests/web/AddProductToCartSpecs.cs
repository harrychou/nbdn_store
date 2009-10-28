 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.dto;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class AddProductToCartSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             AddProductToCart>
         {
        
         }

         [Concern(typeof(AddProductToCart))]
         public class when_observation_name : concern
         {
             context c = () =>
             {
                 request = an<Request>();
                 response_engine = the_dependency<ResponseEngine>();
                 service = the_dependency<ShoppingCartTask>();

                 input_model = new CartItem();

                 cart_items = new List<CartItem>();

                 request.Stub(request1 => request1.map<CartItem>()).Return(input_model);

                 service.Stub(service1 => service1.get_current_cart_content()).Return(cart_items);
             };

             because b = () =>
             {
                sut.process(request);
             };

        
             it should_display_items_in_the_cart = () =>
             {
                 service.received(service1 => service1.add_item(input_model));
                 response_engine.received(response => response.display(cart_items));
             };

             static IEnumerable<CartItem> cart_items;
             static Request request;
             static ResponseEngine response_engine;
             static ShoppingCartTask service;
             static CartItem input_model;
         }
     }
 }
