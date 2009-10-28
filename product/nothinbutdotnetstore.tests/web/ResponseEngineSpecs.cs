using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ResponseEngineSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ResponseEngine,
                                            DefaultResponseEngine> {}

        [Concern(typeof (DefaultResponseEngine))]
        public class when_processing_a_view_model : concern
        {
            context c = () =>
            {
                renderer = the_dependency<ViewFactory>();
                view_for_model = an<ViewForModel<MyModel>>();
                view_model = an<MyModel>();
                renderer.Stub(renderer1 => renderer1.create_view_for(view_model)).Return(view_for_model);

                provide_a_basic_sut_constructor_argument<TransferBehaviour>((handler, form) =>
                {
                    view_transferred_to = handler;
                });
            };

            because b = () =>
            {
                 sut.display(view_model);
            };

            it should_transfer_control_to_the_view_to_render = () =>
            {
                view_transferred_to.should_be_equal_to(view_for_model);
            };

            static MyModel view_model;
            static ViewFactory renderer;
            static ViewForModel<MyModel> view_for_model;
            static IHttpHandler view_transferred_to;
        }

        public class MyModel {}
    }
}