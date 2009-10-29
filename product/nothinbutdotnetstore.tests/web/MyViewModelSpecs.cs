 using System;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.tests.web
 {   
     public class MyViewModelSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             ViewModelDisplay<MyViewModel>>
         {
        
         }

         [Concern(typeof(ViewModelDisplay<MyViewModel>))]
         public class when_requested_to_display_view_model : concern
         {
             context c = () =>
             {
                 request = an<Request>();
                 response_engine = the_dependency<ResponseEngine>();
                 model = new MyViewModel();
                 provide_a_basic_sut_constructor_argument<Func<Request, MyViewModel>>(request1 => model);
             };

             because b = () =>
             {
                 sut.process(request);
             };

        
             it first_observation = () =>
             {
                 response_engine.received(engine => engine.display(model));
             };

             static Request request;
             static ResponseEngine response_engine;
             static MyViewModel model;
         }
     }

     public class MyViewModel {}
 }
