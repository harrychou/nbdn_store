using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewFactorySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ViewFactory,
                                            DefaultViewFactory> {}

        class CreateDetails {
            public string path { get; set; }
            public Type type { get; set; }
        }

        [Concern(typeof (DefaultViewFactory))]
        public class when_creating_a_view : concern
        {
            context c = () =>
            {
                view = an<ViewForModel<int>>();
                view_path_registry = the_dependency<ViewPathRegistry>();
                provide_a_basic_sut_constructor_argument<PageFactory>((path, type) =>
                {
                    details = new CreateDetails {path = path, type = type};
                    return view;
                });

                view_path = "blah.aspx";
                view_path_registry.Stub(registry => registry.get_path_for_view_that_can_render<int>()).Return(view_path);
            };

            because b = () =>
            {
                result = sut.create_view_for(23);
            };


            it should_create_the_appropriate_view_based_on_the_model_to_be_displayed = () =>
            {
                details.path.should_be_equal_to(view_path);
                details.type.should_be_equal_to(typeof(DefaultViewForModel<int>));
                result.should_be_equal_to(view);
            };

            static ViewForModel<int> result;
            static ViewForModel<int> view;
            static ViewPathRegistry view_path_registry;
            static string view_path;
            static CreateDetails details;
        }
    }
}