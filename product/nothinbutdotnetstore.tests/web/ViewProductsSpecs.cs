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
     public class ViewDepartmentProductsSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             ViewDepartmentProducts>
         {
        
         }

         [Concern(typeof(ViewDepartmentProducts))]
         public class when_request_for_products_is_made : concern
         {
             context c = () =>
             {
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();
                service = the_dependency<CatalogTasks>();
                department_whose_products_we_want = new DepartmentItem();

                request.Stub(request1 => request1.map<DepartmentItem>()).Return(department_whose_products_we_want);

                service.Stub(service1 => service1.get_all_products_in(department_whose_products_we_want)).Return(product_list);
             };

             because b = () =>
             {
                sut.process(request);       
             };

        
             it should_display_all_products_in_the_department = () =>
             {

                 response_engine.received(engine => engine.display(product_list));                 
             };

             private static IEnumerable<ProductItem> product_list;
            static Request request;
            static ResponseEngine response_engine;
            static CatalogTasks service;
            static DepartmentItem department_whose_products_we_want;
         }
     }
 }
