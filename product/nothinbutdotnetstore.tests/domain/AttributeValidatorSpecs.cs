 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.domain;
 using nothinbutdotnetstore.infrastructure.validation;

namespace nothinbutdotnetstore.tests.domain
 {   
     public class AttributeValidatorSpecs
     {
         public abstract class concern : observations_for_a_static_sut
         {
        
         }

         [Concern(typeof(AttributeValidator))]
         public class when_customer_is_created_with_invalid_information : concern
         {
             context c = () =>
             {
                 customer = new Customer();
             };

             because b = () =>
             {
                 valid_result = AttributeValidator.validate(customer);
             };

        
             it should_put_the_customer_in_a_invalid_state = () =>
             {
                valid_result.should_be_false();
             };

             static Customer customer;
             static bool valid_result;
         }

         [Concern(typeof(AttributeValidator))]
         public class when_customer_is_created_with_valid_information : concern
         {
             context c = () =>
             {
                 customer = new Customer
                 {
                     first_name = "Harry",
                     last_name = "Awesome",
                     Address = new Address 
                     {
                         street = "happy street 1",
                     },
                     email_address = "harry@happyland.com"
                 };
             };

             because b = () =>
             {
                 valid_result = AttributeValidator.validate(customer);
             };


             it should_put_the_customer_in_a_invalid_state = () =>
             {
                 valid_result.should_be_true();
             };

             static Customer customer;
             static bool valid_result;
         }
     }
 }
