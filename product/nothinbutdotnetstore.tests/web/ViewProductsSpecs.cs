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
    public class ViewProductsOfDepartmentSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             ViewProductsOfDepartment>
         {
        
         }

         [Concern(typeof(ViewProductsOfDepartment))]
         public class when_request_for_viewing_products_is_made : concern
         {
             context c = () =>
             {
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();
                service = the_dependency<CatalogTasks>();
                input_model = new DepartmentItem();

                product_list = new List<ProductItem>();

                request.Stub(request1 => request1.map<DepartmentItem>()).Return(input_model);

                service.Stub(service1 => service1.get_products_in_department(input_model)).Return(product_list);
             };

             because b = () =>
             {
                 sut.process(request);
             };

        
             it should_display_all_products_in_the_department = () =>
             {
                 response_engine.received(engine => engine.display(product_list));
                
            
             };

             static Request request;
             static ResponseEngine response_engine;
             static CatalogTasks service;
             static DepartmentItem input_model;
             static IEnumerable<ProductItem> product_list;
         }
     }

 }
