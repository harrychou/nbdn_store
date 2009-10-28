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
     public class ViewSubDepartmentSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             ViewSubDepartmentCommand>
         {
        
         }

         [Concern(typeof(ViewSubDepartmentCommand))]
         public class when_requested_to_display_sub_departments : concern
         {
             context c = () =>
             {
                 request = an<Request<string>>();
                 request.model = "FOOD";

                 response_engine = the_dependency<ResponseEngine>();
                 provide_a_basic_sut_constructor_argument("DepartmentBrowser.aspx");
                 service = the_dependency<CatalogTasks>();

                 sub_department_list = new List<DepartmentItem>();

                 service
                     .Stub(service1 => service1.get_sub_departments(request.model))
                     .Return(sub_department_list);
        

             };

             because b = () =>
             {
                sut.process(request);
             };

             it should_display_the_mainsub_departments = () =>
             {
                 response_engine.received(result1 => result1.display(sub_department_list));
             };

             static Request<string> request;
             static ResponseEngine response_engine;
             static CatalogTasks service;
             static IEnumerable<DepartmentItem> sub_department_list;
         }
     }
 }
