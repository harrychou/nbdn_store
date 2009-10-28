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
     public class AddToCartSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
             AddToCart>
         {
           
         }

         [Concern(typeof(AddToCart))]
         public class when_the_user_adds_a_product_to_the_cart : concern
         {
             context c = () =>
             {
                 request = an<Request>();
                 service = the_dependency<ShoppingCartTask>();
                 input_model = new LineItem();
                 request.Stub(r => r.map<LineItem>()).Return(input_model);
             };

             because b = () =>
             {
                sut.process(request);       
             };

        
             it should_add_the_correct_quantity_and_product_id = () =>
             {
                 service.received(service1 => service1.add_product_to_cart(input_model));
             };

             private static ShoppingCartTask service;
             private static Request request;
             private static LineItem input_model;
         }
     }
 }
