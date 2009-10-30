using System;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class TypeMapper : Mapper<string,Type>
    {
        public Type map(string full_type_name)
        {
            return Type.GetType(full_type_name);
        }
    }
}