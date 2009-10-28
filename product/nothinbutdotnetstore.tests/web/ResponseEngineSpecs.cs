 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.dto;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ResponseEngineSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ResponseEngine,
                                             DefaultResponseEngine>
         {
         }

         [Concern(typeof(DefaultResponseEngine))]
         public class when_processing_a_view_model : concern
         {
             context c = () =>
             {
                 renderer = the_dependency<ViewBuilder>();
                 view_for_model = an<ViewForModel<IEnumerable<DepartmentItem>>>();
                 renderer.Stub(renderer1 => renderer1.build_view(view_model)).Return(view_for_model);
             };

             because b = () =>
             {
                 sut.display(view_model);
             };

        
             it should_set_date_to_context_and_transfer_view = () =>
             {
                 view_for_model.received(model => model.display());
             };

             static IEnumerable<DepartmentItem> view_model;
             static ViewBuilder renderer;
             static ViewForModel<IEnumerable<DepartmentItem>> view_for_model;
         }
     }
 }
