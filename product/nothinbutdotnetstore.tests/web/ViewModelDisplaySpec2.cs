 using System;
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
     public class ViewModelDisplaySpec2
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             ViewModelDisplay<IEnumerable<DepartmentItem>, CatalogTasks>>
         {
        
         }

         [Concern(typeof(ViewModelDisplay<,>))]
         public class when_requested_to_display_view_model : concern
         {
             context c = () =>
             {
                 request = an<Request>();
                 view_model = new List<DepartmentItem>();
                 
                 response_engine = the_dependency<ResponseEngine>();
                 service_component = the_dependency<CatalogTasks>();

                 service_component.Stub(catalog_tasks => catalog_tasks.get_main_departments()).Return(view_model);

                 provide_a_basic_sut_constructor_argument<Func<Request, CatalogTasks, IEnumerable<DepartmentItem>>>
                     (
                        (request1, task) => task.get_main_departments()
                     );
             };


             because b = () =>
             {
                 sut.process(request);
        
             };
        
             it should_display_the_view_model = () =>
             {
                 response_engine.received(engine => engine.display(view_model));
             };

             static ResponseEngine response_engine;
             static IEnumerable<DepartmentItem> view_model;
             static CatalogTasks service_component;
             static Request request;
         }
     }
 }
