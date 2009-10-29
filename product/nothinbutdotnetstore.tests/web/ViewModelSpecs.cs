using System;
using System.Collections;
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
    public class ViewModelSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                            ViewModelDisplay<IEnumerable<DepartmentItem>>> {}

        [Concern(typeof (ViewModelDisplay<>))]
        public class when_requested_to_display_sub_departments : concern
        {
            context c = () =>
            {
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();
                input_model = new DepartmentItem();
                sub_department_list = new List<DepartmentItem>();
                service = an<CatalogTasks>();

                provide_a_basic_sut_constructor_argument(new Func<Request, IEnumerable<DepartmentItem>> (x => service.get_all_subdepartments_in(input_model)));
                

                request.Stub(request1 => request1.map<DepartmentItem>()).Return(input_model);
                service.Stub(service1 => service1.get_all_subdepartments_in(input_model)).Return(sub_department_list);

            };

            because b = () =>
            {
                sut.process(request);
            };

            it should_display_the_sub_departments = () =>
            {
                response_engine.received(result1 => result1.display(sub_department_list));
            };

            static Request request;
            static ResponseEngine response_engine;
            static CatalogTasks service;
            static IEnumerable<DepartmentItem> sub_department_list;
            static DepartmentItem input_model;
        }
    }

    public class ViewModel {}
}