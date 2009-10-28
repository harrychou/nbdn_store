using System.Collections;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ViewDepartmentCommandSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             ViewDepartmentCommand>
         {
        
         }

         [Concern(typeof(ViewDepartmentCommand))]
         public class when_user_requeste_to_view_departments : concern
         {
             context c = () =>
             {
                 request = an<Request>();
                 result = the_dependency<Result>();
                 provide_a_basic_sut_constructor_argument("DepartmentBrowser.aspx");
                 service = the_dependency<ViewDepartmentService>();

                 departmentList = new List<string> {"Dept1"};

                 service.Stub(service1 => service1.GetDepartmentName()).Return(departmentList);
             };

             because b = () =>
             {
                 sut.process(request);
             };

             it should_render_a_list_of_department_names_to_the_renderer = () =>
             {
                 result.data.should_be_equal_to(departmentList);
                 result.received(result1 => result1.render());
             };

             static IEnumerable<string> department_names;
             static Request request;
             static Result result;
             static string view_name;
             static ViewDepartmentService service;
             static IEnumerable<string> departmentList;
         }
     }
 }
