using System;

namespace nothinbutdotnetstore.infrastructure.validation
{
    public class AttributeValidator
    {
        static public bool validate<T>(T obj)
        {
            var properties = typeof (T).GetProperties();
            foreach (var info in properties)
            {
                if (Attribute.IsDefined(info, typeof (RequiredFieldAttribute))) 
                {
                    var attribute = Attribute.GetCustomAttribute(info, typeof (RequiredFieldAttribute));
                    if (!attribute.is_valid((IComparable)info.GetValue(obj, null))) return false;
                }
            }

            return true;
        }
    }

    static public class AttributeExtension
    {
        static public bool is_valid<T>(this Attribute attribute, T obj) where T : IComparable<T>
        {
            return (obj.CompareTo(default(T)) != 0);
        }
    }
}