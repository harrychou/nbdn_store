using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.tests.utility;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestHandlerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<IHttpHandler,
                                            RequestHandler> {}

        [Concern(typeof (RequestHandler))]
        public class when_handling_an_incoming_http_context : concern
        {
            context c = () =>
            {
                http_context = ObjectMother.create_http_context();
                request = an<Request>();
                front_controller = the_dependency<FrontController>();
                request_factory = the_dependency<FrontControllerRequestFactory>();
                request_factory.Stub(factory => factory.create_from(http_context)).Return(request);
            };

            because b = () =>
            {
                sut.ProcessRequest(http_context);
            };

            it should_delegate_the_processing_of_the_request_to_our_front_controller = () =>
            {
                front_controller.received(controller1 => controller1.process(request));
            };

            static FrontController front_controller;
            static Request request;
            static HttpContext http_context;
            static FrontControllerRequestFactory request_factory;
        }
    }
}