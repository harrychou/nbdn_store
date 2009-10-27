using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.tests.utility;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class CommandSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Command,
                                             ViewDepartmentStoreCommand>
         {
        
         }

         [Concern(typeof(ViewDepartmentStoreCommand))]
         public class when_receiving_a_request_that_can_be_handled : concern
         {
             context c = () =>
             {
                 var request_name = "view_department";

                 request_that_can_be_handled = an<Request>();
                 request_that_can_be_handled.name = request_name;

                 provide_a_basic_sut_constructor_argument(request_name);
             };

             because b = () =>
             {
                 response = sut.can_handle(request_that_can_be_handled);
             };

        
             it should_return_true = () =>
             {
                 response.should_be_true();
             };

             static Request request_that_can_be_handled;
             static bool response;
         }

         [Concern(typeof(ViewDepartmentStoreCommand))]
         public class when_receiving_a_request_that_can_not_be_handled : concern
         {
             context c = () =>
             {
                 var request_name = "view_department";

                 request_that_can_be_handled = an<Request>();
                 request_that_can_be_handled.name = request_name;

                 provide_a_basic_sut_constructor_argument("");
             };

             because b = () =>
             {
                 response = sut.can_handle(request_that_can_be_handled);
             };


             it should_return_false = () =>
             {
                 response.should_be_false();
             };

             static Request request_that_can_be_handled;
             static bool response;
         }

         [Concern(typeof(ViewDepartmentStoreCommand))]
         public class when_processing_a_request_to_view_major_department_stores : concern
         {
             context c = () =>
             {
                 var request_name = "view_department";

                 request = an<Request>();
                 request.name = request_name;

                 provide_a_basic_sut_constructor_argument(request_name);

                 department_store_service = the_dependency<DepartmentStoreService>();

             };

             because b = () =>
             {
                 response = sut.process(request);
             };


             it should_return_false = () =>
             {
                department_store_service.received(service => service.get_main_department_stores());
             };

             static Request request;
             static object response;
             static DepartmentStoreService department_store_service;
         }
     }
 }
