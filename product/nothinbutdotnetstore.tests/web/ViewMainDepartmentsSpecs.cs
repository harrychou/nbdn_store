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
     public class ViewMainDepartmentsSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             ViewMainDepartments>
         {
        
         }

         [Concern(typeof(ViewMainDepartments))]
         public class when_user_requeste_to_view_departments : concern
         {
             context c = () =>
             {
                 request = an<Request>();
                 response_engine = the_dependency<ResponseEngine>();
                 service = the_dependency<CatalogTasks>();

                 department_list = new List<DepartmentItem>();

                 service.Stub(service1 => service1.get_main_departments()).Return(department_list);
             };

             because b = () =>
             {
                 sut.process(request);
             };

             it should_render_a_list_of_department_names_to_the_renderer = () =>
             {
                 response_engine.received(result1 => result1.display(department_list));
             };

             static Request request;
             static ResponseEngine response_engine;
             static CatalogTasks service;
             static IEnumerable<DepartmentItem> department_list;
         }
     }
 }
