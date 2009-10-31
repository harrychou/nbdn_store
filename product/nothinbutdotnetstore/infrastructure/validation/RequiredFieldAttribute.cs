using System;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredFieldAttribute : Attribute
    {
        public bool is_valid(object target)
        {
            throw new NotImplementedException();
        }

        public PropertyInfo property_to_validate { get; set; }
    }
}