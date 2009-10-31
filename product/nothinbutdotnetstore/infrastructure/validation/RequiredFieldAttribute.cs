using System;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredFieldAttribute : Attribute
    {
        public bool is_valid(object target)
        {
            var value = property_to_validate.GetValue(target, null);

            return value != null;
        }

        public PropertyInfo property_to_validate { get; set; }
    }
}