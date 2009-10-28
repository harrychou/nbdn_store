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
                 result = the_dependency<Result>();
                 provide_a_basic_sut_constructor_argument("DepartmentBrowser.aspx");
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
                 result.received(result1 => result1.render(department_list));
             };

             static Request request;
             static Result result;
             static CatalogTasks service;
             static List<DepartmentItem> department_list;
         }
     }
 }
