using System.Reflection;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.validation;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class RequiredFieldAttributeSpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<RequiredFieldAttribute> {}

        [Concern(typeof (RequiredFieldAttribute))]
        public class when_validating_a_property_and_the_property_has_a_value : concern
        {
            context c = () =>
            {
                item_to_validate = new ItemToValidate {name = "JP"};
                name_property = typeof(ItemToValidate).GetProperty("name");
            };

            after_the_sut_has_been_created ac = () =>
            {
                sut.property_to_validate = name_property;
            };

            because b = () =>
            {
                result = sut.is_valid(item_to_validate);
            };


            it should_be_valid = () =>
            {
                result.should_be_true();
            };

            static bool result;
            static ItemToValidate item_to_validate;
            static PropertyInfo name_property;
        }

        public class ItemToValidate
        {
            [RequiredField]
            public string name { get; set; }
        }
    }
}